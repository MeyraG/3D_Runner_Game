using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _boundX = 6.6f;

    public void OnDelta(Vector2 onDelta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x += onDelta.x;
        
        newPos.x = Mathf.Clamp(newPos.x, -_boundX, _boundX);
        
        transform.localPosition = newPos;
    }

    private void Update()
    {
        // Player moves continuously to forward!
        transform.Translate(Vector3.forward * (_moveSpeed * Time.deltaTime));
    }

    //Floating Joystick Movement.
    //But we are gonna implement the Jump mechanic.
    //If we want to move player continuously to the direction that we want then we can use Joystick
    /*private void Update()
    {
        Vector3 newPos = transform.localPosition;

        float joystickX = _floatingJoystick.Horizontal;

        newPos.x += joystickX * _moveSpeed * Time.deltaTime;
        
        newPos.x = Mathf.Clamp(newPos.x, -_boundX, _boundX);
        
        transform.localPosition = newPos;
    }*/

    /*void FixedUpdate()
    {
        _rigidbody.AddForce(0, 0, _forwardForce * Time.deltaTime);

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
            _firstPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            _endPosition = Input.mousePosition;
            float dif = _endPosition.x - _firstPosition.x;
            transform.Translate(dif * Time.deltaTime * _sidesForce, 0, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _firstPosition = Vector3.zero;
            _endPosition = Vector3.zero;
        }

        Vector3 position = transform.position;

        if (transform.position.x > _boundX)
        {
            position.x = _boundX;
        }
        else if (transform.position.x < -_boundX)
        {
            position.x = -_boundX;
        }
        transform.position = position;

        //Burada player.pos.y'nin eksiye dusmesini kontrol edicez
        if (_rigidbody.position.y < -3f)
        {
            GameManager.Instance.LevelFailed();
        }
    }*/
}