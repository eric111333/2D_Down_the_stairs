using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public static int potionNum=3;
    public Text potionText;
    public Text atkDamage;
    public Text HpPuls;
    public static int atkDamageNum=10;
    public GameObject Fireball;
    public GameObject target;
    public GameObject printitem;
    public Text goldNum;
    public Text goldNum1;
    public Image fire;
    private float firetime;
    private float fireCDtime=2;
    Vector3 t0 = new Vector3(0, 0, 0);
    public static int HpPulsNum=10;


    void Start()
    {
        //potionNum = 3;
        //atkDamageNum = 10;
        //HpPulsNum = 10;

    }
    public void skill()
    {

        if (fire.fillAmount >= 1&&Player.mp>=2)
        { 
        float x = target.GetComponent<Transform>().position.x+1.5f;
        float x1 = target.GetComponent<Transform>().position.x - 1.5f;
        float y = target.GetComponent<Transform>().position.y;
        Vector3 pos = new Vector3(x, y, 0);
        Vector3 pos1 = new Vector3(x1, y, 0);
            if (Player.front==true)
        Instantiate(Fireball, pos, Quaternion.identity);
            if(Player.front==false)
        Instantiate(Fireball, pos1, Quaternion.identity);
            fire.fillAmount = 0;
        Player.mp-=2;
        }   
        if(Player.mp<=1)
            {
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "魔力不足";
        }

    }

    public void PulsDamage()
    {
        
        if (Player.goldNum >= atkDamageNum * 10)
        {
            atkDamageNum++;
            attack.attackDamage++;
            Player.goldNum -= atkDamageNum*10;
            goldNum.text = "" + atkDamageNum * 10;
            atkDamage.text = "" + atkDamageNum;
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "攻擊力=" + atkDamageNum ;
        }
     if (Player.goldNum <= atkDamageNum * 10)
        {
        GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "金錢不足";
        }
            
    }
    public void PulsHp()
    {
        if(Player.goldNum >= HpPulsNum * 10)
        {
            HpPulsNum++;
            Player.hpMax += 10;
            Player.hp += 10;
            Player.goldNum -= HpPulsNum * 10;
            goldNum1.text = "" + HpPulsNum * 10;
            HpPuls.text = "" + HpPulsNum;
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "HPMAX+" + 10;
        }
        if (Player.goldNum <= HpPulsNum * 10)
        {
            GameObject points = Instantiate(printitem, t0, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = "金錢不足";
        }
    }

    public void pot()
    {

        if (potionNum > 0 && Player.hp <=Player.hpMax-20)
        {
            potionNum--;
            Player.hp += 20;
        }
    }

    void Update()
    {
        potionText.text = "" + potionNum;
        firetime += Time.deltaTime;
        if(fire.fillAmount==0)
        { if (firetime >= fireCDtime) firetime = 0;}
            
        fire.fillAmount = firetime / fireCDtime;
    }
}
