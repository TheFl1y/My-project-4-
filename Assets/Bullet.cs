using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float 存活時間 = 1.5f;
    float 結束時間;

    // Start is called before the first frame update
    void Start()
    {
        結束時間 = Time.time + 存活時間;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= 結束時間)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("主角")){
            Destroy(gameObject);
        }
    }
}
