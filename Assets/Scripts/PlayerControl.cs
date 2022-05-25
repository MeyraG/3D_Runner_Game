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
    float boundX = 6.6f;

    Vector3 firstPosition, endPosition;

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.AddForce(sidesForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //Velocity.change kutleyi hesaba katmadan kuvvet uyguluyor.Kuvvetin birimi mesafe /zaman
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.AddForce(-sidesForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            firstPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            float dif = endPosition.x - firstPosition.x;
            transform.Translate(dif * Time.deltaTime * sidesForce, 0, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            firstPosition = Vector3.zero;
            endPosition = Vector3.zero;
        }

        Vector3 position = transform.position;

        if (transform.position.x > boundX)
        {
            position.x = boundX;
        }
        else if (transform.position.x < -boundX)
        {
            position.x = -boundX;
        }
        transform.position = position;

        //Burada player.pos.y'nin eksiye dusmesini kontrol edicez
        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}