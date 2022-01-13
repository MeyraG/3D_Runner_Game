using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    
    public GameManager gameManager;

  
    void OnTriggerEnter(Collider other)
    {
        gameManager.LevelComplete();
        gameManager.player.gameObject.GetComponent<PlayerControl>().enabled = false;
    }
}