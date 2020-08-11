using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public void StartGame()
    {
        SceneManager.LoadScene("選單");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
   
}
