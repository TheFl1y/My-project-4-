using UnityEngine;

public class 移動 : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 500.0f;
    public float groundFriction = 15.0f; // 地面摩擦力
    public float airFriction = 0.5f; // 空中摩擦力
    public float maxSpeed = 10.0f;
    public float verticalLookSpeed = 3.0f; // 垂直看向速度
    public float minVerticalLookAngle = -70.0f; // 最小垂直看向角度
    public float maxVerticalLookAngle = 80.0f; // 調整最大垂直看向角度

    public GameObject 攻擊特效, 特效位置, 攻擊氣功彈;
    GameObject 播放中特效;
    public AudioClip 攻擊音效;
    Animator 動畫控制器;

    private Rigidbody rb;
    private Transform cameraPivot; // New variable to store camera pivot

    void Start()
    {
        動畫控制器 = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;


        // Create an empty GameObject as the camera pivot
        cameraPivot = new GameObject("CameraPivot").transform;
        cameraPivot.SetParent(transform);
        cameraPivot.localPosition = new Vector3(0, 1.5f, 0); // Adjust the position as needed

        Camera.main.transform.SetParent(cameraPivot); // Attach the camera to the pivot

        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 relativeMoveDirection = transform.TransformDirection(moveDirection);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera pivot for vertical movement with custom clamping
        float newRotationX = ClampVerticalRotation(cameraPivot.localEulerAngles.x - mouseY * verticalLookSpeed);
        cameraPivot.localEulerAngles = new Vector3(newRotationX, 0, 0);

        // Rotate the player for horizontal movement
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        rb.AddForce(relativeMoveDirection * speed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        float friction = IsGrounded() ? groundFriction : airFriction;
        Vector3 frictionForce = -rb.velocity.normalized * friction;
        rb.AddForce(frictionForce, ForceMode.Acceleration);

        if (Input.GetMouseButton(0))
            動畫控制器.SetBool("Attack", true);
        else
            動畫控制器.SetBool("Attack", false);

        
    }

    float ClampVerticalRotation(float angle)
    {
        // Custom method to clamp the vertical rotation
        if (angle > 180f)
            return Mathf.Clamp(angle, 360f - maxVerticalLookAngle, 360f - minVerticalLookAngle);
        else
            return Mathf.Clamp(angle, minVerticalLookAngle, maxVerticalLookAngle);
    }

    public void Hit(float 傳入值)
    {
        print(傳入值);
    }

    public void 特效開始()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            // 获取鼠标点击位置
            Vector3 targetPosition = hit.point;

            // 计算方向向量
            Vector3 direction = (targetPosition - 特效位置.transform.position).normalized;

            // 创建并初始化氣功彈
            GameObject 已發射氣功彈 = Instantiate(攻擊氣功彈, 特效位置.transform.position, Quaternion.identity);
            已發射氣功彈.GetComponent<Rigidbody>().AddForce(direction * 1000);
        }
    }

    public void 特效結束()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Destroy(播放中特效, ps.main.duration);
    }

    bool IsGrounded()
    {
        // 使用射线检测是否在地面上
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }
}
