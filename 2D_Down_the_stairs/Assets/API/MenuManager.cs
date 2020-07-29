using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
    private void Start()
    {
        Screen.SetResolution(480, 854, false);
    }

    public void Easy()
    {
        Player.hp = 10000;
        Player.hpMax = 10000;
    }

    public void Mid()
    {
        Player.hp = 1000;
        Player.hpMax = 1000;
    }
    public void Difficult()
    {
        Player.hp = 100;
        Player.hpMax = 100;
    }

}
