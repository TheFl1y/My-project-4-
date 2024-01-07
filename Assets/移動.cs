using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class 移動 : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 500.0f;
    public float groundFriction = 15.0f; // 地面摩擦力
    public float airFriction = 0.5f; // 空中摩擦力
    public float maxSpeed = 10.0f;

    private Rigidbody rb;

    public GameObject 攻擊特效, 特效位置,攻擊氣功彈;
    GameObject 播放中特效; 
    public AudioClip 攻擊音效;
    Animator 動畫控制器;

    void Start()
    {
        動畫控制器 = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        // 锁定物体的旋转，防止翻转
        rb.freezeRotation = true;
    }

    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);

        
        Vector3 relativeMoveDirection = transform.TransformDirection(moveDirection);

     
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
    public void Hit(float 傳入值)
    {
        print(傳入值);
    }

    public void 特效開始()
    {
        播放中特效 = Instantiate(攻擊特效, 特效位置.transform);
        AudioSource.PlayClipAtPoint(攻擊音效, 特效位置.transform.position, 1);
        GameObject 已發射氣功彈 = Instantiate(攻擊氣功彈, 特效位置.transform.position, Quaternion.Euler(0, 0, 0));
        已發射氣功彈.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);

    }
    public void 特效結束()
    {
        Destroy(播放中特效);
    }
    bool IsGrounded()
    {
        // 使用射线检测是否在地面上
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }
    
}
