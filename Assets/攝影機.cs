using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攝影機 : MonoBehaviour
{
    public Transform 目標位置;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = 目標位置.position;
        transform.rotation = 目標位置.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, 目標位置.position, Time.deltaTime * 3f);
        transform.rotation = Quaternion.Lerp(transform.rotation, 目標位置.rotation, Time.deltaTime * 3f);
    }
}
