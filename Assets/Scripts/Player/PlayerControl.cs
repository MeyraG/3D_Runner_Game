using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _forwardForce = 2000f; 
    [SerializeField] private float _sidesForce = 0.3f;
    
    private Rigidbody _rigidbody;
    private Vector3 _firstPosition, _endPosition;
    
    private float _boundX = 6.6f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
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
    }
}