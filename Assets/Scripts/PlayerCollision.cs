using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerControl control;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hit the rock, Jack");
            control.enabled = false;

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
