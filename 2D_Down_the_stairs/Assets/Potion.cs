using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public static int potionNum;
    public Text potionText;
    public Text atkDamage;
    public static int atkDamageNum;
    public GameObject Fireball;
    public GameObject target;
    public Image fire;
    private float firetime;
    private float fireCDtime=2;

    void Start()
    {
        potionNum = 3;
        atkDamageNum = 10;
    }
    public void skill()
    {
        if (fire.fillAmount >= 1)
        { 
        float x = target.GetComponent<Transform>().position.x +1;
        float y = target.GetComponent<Transform>().position.y;
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(Fireball, pos, Quaternion.identity);
        fire.fillAmount = 0;
        }   
    }

    public void PulsDamage()
    { 
     if (Player.goldNum >= 100)
        {
            atkDamageNum++;
            attack.attackDamage++;
            Player.goldNum -= 100;
            atkDamage.text = "" + atkDamageNum;
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
