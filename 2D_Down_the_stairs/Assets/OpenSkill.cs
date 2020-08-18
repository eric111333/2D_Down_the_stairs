
using UnityEngine;

public class OpenSkill : MonoBehaviour
{
    public GameObject skill;
    public bool skillOpen;
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        skillOpen = !skillOpen;
        skill.SetActive(skillOpen);
    }
    void Update()
    {
        
    }
}
