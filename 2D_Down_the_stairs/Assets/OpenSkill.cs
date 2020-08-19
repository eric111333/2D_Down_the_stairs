
using UnityEngine;

public class OpenSkill : MonoBehaviour
{
    public GameObject skill;
    public GameObject team;
    public bool skillOpen;
    public bool teamOpen;
    void Start()
    {
        
    }
  

    public  void openskill()
    {
        skillOpen = !skillOpen;
        skill.SetActive(skillOpen);
    }
    public void openteam()
    {
        teamOpen = !teamOpen;
        team.SetActive(teamOpen);
    }

    void Update()
    {
        
    }
}
