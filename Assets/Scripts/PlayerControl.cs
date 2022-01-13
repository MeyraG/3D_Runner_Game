using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField]
    float forwardForce = 2000f; 
    [SerializeField]
    float sidesForce = 400f;


    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidesForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //Velocity.change kutleyi hesaba katmadan kuvvet uyguluyor.Kuvvetin birimi mesafe /zaman
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-sidesForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Burada player.pos.y'nin eksiye dusmesini kontrol edicez
        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}