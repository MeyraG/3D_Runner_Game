using System;
using DG.Tweening;
using Lean.Touch;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckSphereRadius;
    [SerializeField] private float _boundX = 6.6f;

    private Rigidbody _rigidbody;
    private int _sphereCastResultsCount;

    private RaycastHit[] _sphereCastResults = new RaycastHit[1];
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnDelta(Vector2 onDelta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x += onDelta.x;

        newPos.x = Mathf.Clamp(newPos.x, -_boundX, _boundX);

        transform.localPosition = newPos;
    }

    public void OnSwipeUp(Vector2 onDelta)
    {
        if (GroundCheck())
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void Update()
    {
        // Player moves continuously to forward!
        transform.Translate(Vector3.forward * (_moveSpeed * Time.deltaTime));
    }

    private bool GroundCheck()
    {
        Vector3 playerOrigin = transform.position;
        playerOrigin.y -= 1f;

        //Ground Cast
        //Generates no garbage. See: https://docs.unity3d.com/2020.3/Documentation/ScriptReference/Physics.SphereCastNonAlloc.html
        _sphereCastResultsCount = Physics.SphereCastNonAlloc(playerOrigin, _groundCheckSphereRadius, Vector3.down,
            _sphereCastResults, _groundDistance, _groundMask.value);

        _isGrounded = _sphereCastResultsCount != 0;

        return _isGrounded;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 playerOrigin = transform.position;
        playerOrigin.y -= 1f;
        
        Gizmos.color = Color.red;
        Debug.DrawLine(playerOrigin, playerOrigin + Vector3.down * _groundDistance, Color.green);
        Gizmos.DrawWireSphere(playerOrigin + Vector3.down * _groundDistance, _groundCheckSphereRadius);
    }

    #region Floating Joystick Movement

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

    #endregion
    
    #region Old Move System

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

    #endregion
}