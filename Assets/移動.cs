using UnityEngine;

public class 移動 : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 500.0f;
    public float groundFriction = 15.0f; // 地面摩擦力
    public float airFriction = 0.5f; // 空中摩擦力
    public float maxSpeed = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 锁定物体的旋转，防止翻转
        rb.freezeRotation = true;
    }

    void Update()
    {
        // 获取用户输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // 旋转物体（使用滑鼠输入）
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        // 将移动方向转换为相对于当前面对方向的方向
        Vector3 relativeMoveDirection = transform.TransformDirection(moveDirection);

        // 移动物体
        rb.AddForce(relativeMoveDirection * speed);

        // 限制速度上限
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        // 根据是否在地面上应用不同的摩擦力
        float friction = IsGrounded() ? groundFriction : airFriction;

        // 增加摩擦力
        Vector3 frictionForce = -rb.velocity.normalized * friction;
        rb.AddForce(frictionForce, ForceMode.Acceleration);
    }

    bool IsGrounded()
    {
        // 使用射线检测是否在地面上
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }
}
