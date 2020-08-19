using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public static int potionNum;
    public Text potionText;
    void Start()
    {
        potionNum = 20;
    }


    private void OnMouseDown()
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
       
    }
}
