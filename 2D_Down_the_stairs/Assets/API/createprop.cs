using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Threading;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class createprop : MonoBehaviour
{
    [Header("要生成的道具")]
    public GameObject prop;
    [Header("x 軸最小值")]
    public float xMin;
    [Header("x 軸最大值")]
    public float xMax;
    [Header("生成頻率"), Range(0.1f, 3f)]
    public float interval = 1;
    public float timer_f = 0f;
    public int timer_i = 0;
    public float y;


    /// <summary>
    /// 建立物件
    /// </summary>
    private void createpropObject()
    {
        y = y - timer_i;
        float x =Random.Range(xMax, xMin);
        
        Vector3 pos = new Vector3(x, y, 0);
        

        Instantiate(prop, pos, Quaternion.identity);
    }
    
   private void Start()
    {
        float r = Random.Range(0f, 2f);
        
        InvokeRepeating("createpropObject", r, interval);
    }
    void Update()
    {
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        Debug.Log(timer_i);
        
        
    }

}
