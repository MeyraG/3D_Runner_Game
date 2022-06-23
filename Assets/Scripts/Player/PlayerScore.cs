using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    void Update()
    {
        _scoreText.text =  transform.position.z.ToString("0");
    }
}