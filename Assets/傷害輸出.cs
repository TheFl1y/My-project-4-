using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum 角色種類 { 主角, 敵人};
public class 傷害輸出 : MonoBehaviour
{
    public 角色種類 角色;
    public float 傷害值;
    public bool 攻擊中 = false;
    public ParticleSystem 擊中特效;
    Vector3 撞擊點;
    GameObject 撞擊物件;
    public AudioClip 擊中音效;
    private void OnCollisionEnter(Collision 撞擊資訊)
    {
        撞擊物件 = 撞擊資訊.gameObject;
        撞擊點 = 撞擊資訊.contacts[0].point;
        if (攻擊中)
            播放特效();
    }
    private void OnTriggerEnter(Collider 碰撞器)
    {
        撞擊物件 = 碰撞器.gameObject;
        撞擊點 = 碰撞器.bounds.ClosestPoint(transform.position);
        if (攻擊中)
            播放特效();
    }
    public void 播放特效()
    {
        AudioSource.PlayClipAtPoint(擊中音效, 撞擊點);
        StartCoroutine("特效處理", Instantiate(擊中特效, 撞擊點, Quaternion.Euler(Vector3.zero), 撞擊物件.transform));
    }
    IEnumerator 特效處理(ParticleSystem 特效)
    {
        print("1");
        
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

