﻿using UnityEngine;
using UnityEngine.UI;

public class GroundNum : MonoBehaviour
{
    public float gameTime;
    public Text gametext;
    public GameObject boss;
    public int bossNum;
    public GameObject endground;
    //public Transform startline;
    void Boss()
    {

        Vector3 poss = new Vector3(0, 0, 0);
        if (gameTime <= 0&&bossNum>=1)
        {
            bossNum--;
            endground.SetActive(true);
            Instantiate(boss, poss, Quaternion.identity);
        }
        
    }
    private void Update()
    {
        gameTime -= Time.deltaTime;
        gametext.text = "BOSS出擊" + gameTime.ToString("000")+"秒";
        Boss();
    }
    
    /*    public Text displayCountFloor;
        private int point;
        void Start()
        {

        }
        void DisplayCountFloor()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(4, 0), -transform.right * 8f);


            displayCountFloor.text = "第" + point.ToString("000") + "層";
        }
        void Update()
        {
            DisplayCountFloor();
        }
        private void OnDrawGizmos()
        {
            //Gizmos.DrawRay(groundcheck.position + new Vector3(4, 0), -transform.right * 8f);
            //Gizmos.DrawRay(groundcheck.position + new Vector3(0, 0), transform.right * 4f);
        }*/
}
