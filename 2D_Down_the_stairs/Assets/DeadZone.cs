using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Media;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("玩家"))
        {
            Player.isDead = true;
           // Debug.Break();
        }
    }
}
