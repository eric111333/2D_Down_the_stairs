using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public Button restartButton1;
    public GameObject player;
    private bool gameOver;

    public void StartGame()
    {
        SceneManager.LoadScene("選單");
    }
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        restartButton1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player.isDead)
         {
           //player.SetActive(false);
           restartButton.gameObject.SetActive(true);
           restartButton1.gameObject.SetActive(true);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
   
}
