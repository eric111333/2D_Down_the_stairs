using UnityEngine;
using UnityEngine.UI;

public class GroundNum : MonoBehaviour
{
    public float gameTime;
    public Text gametext;
    private void Update()
    {
        gameTime -= Time.deltaTime;
        gametext.text = "BOSS出擊" + gameTime.ToString("000.0")+"秒";
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
