using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    void OnCollisionEnter2D(Collider2D collision) //aaa為自定義碰撞事件
    {
        if (collision.tag == "Ground") //如果aaa碰撞事件的物件標籤名稱是test
        {
            Destroy(collision.gameObject); //刪除碰撞到的物件(CubeA)
        }
    }
}
