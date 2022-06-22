using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerControl _playerControl;

    private void Awake()
    {
        _playerControl = GetComponent<PlayerControl>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit the rock, Jack");
            _playerControl.enabled = false;

            GameManager.Instance.LevelFailed();
        }
    }
}
