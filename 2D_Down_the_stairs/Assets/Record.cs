using UnityEngine.SceneManagement;
using UnityEngine;

public class Record : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetFloat("playerhpMax",Player.hpMax);
        PlayerPrefs.SetInt("goldNum", Player.goldNum);
        PlayerPrefs.SetInt("potionNum", Potion.potionNum);
        PlayerPrefs.SetFloat("attackSpeed", attack.attackSpeed);
        PlayerPrefs.SetInt("attackDamage", attack.attackDamage);
        //PlayerPrefs.SetFloat("volume", AudioSource);

    }
    public void nextscene()
    {
        SceneManager.LoadScene("選單");
    }

    
    void Update()
    {
        
    }
}
