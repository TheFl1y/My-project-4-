using System.Collections;
using UnityEngine;

public enum 角色種類 { 主角, 敵人 };

public class 傷害輸出 : MonoBehaviour
{
    public 角色種類 角色;
    public float 傷害值 = 5f;
    public bool 攻擊中 = false;
    public ParticleSystem 擊中特效;
    Vector3 撞擊點;
    GameObject 撞擊物件;
    public AudioClip 擊中音效;

    private void OnCollisionEnter(Collision 撞擊資訊)
    {
        
        HandleCollision(撞擊資訊.gameObject, 撞擊資訊.contacts[0].point);
    }

    private void OnTriggerEnter(Collider 碰撞器)
    {
        HandleCollision(碰撞器.gameObject, 碰撞器.bounds.ClosestPoint(transform.position));
    }

    private void HandleCollision(GameObject otherObject, Vector3 hitPoint)
    {
        撞擊物件 = otherObject;
        撞擊點 = hitPoint;

        // Check if the collided object has the EnemyHP script
        EnemyHP enemyHP = 撞擊物件.GetComponent<EnemyHP>();
        if(撞擊物件.CompareTag("牆壁") ||撞擊物件.CompareTag("敵人") ){
            Destroy(gameObject);
        }
        if (enemyHP != null && 攻擊中)
        {
            // Apply damage to the enemy
            enemyHP.TakeDamage(傷害值);

            // Play effects
            播放特效();
        }
    }

    public void 播放特效()
    {
        AudioSource.PlayClipAtPoint(擊中音效, 撞擊點);
        StartCoroutine(特效處理(Instantiate(擊中特效, 撞擊點, Quaternion.Euler(Vector3.zero), 撞擊物件.transform)));
    }

    IEnumerator 特效處理(ParticleSystem 特效)
    {
        yield return new WaitForSeconds(.1f);
        Destroy(特效);
    }

    public void 攻擊開始()
    {
        攻擊中 = true;
    }

    public void 攻擊結束()
    {
        攻擊中 = false;
    }
}
