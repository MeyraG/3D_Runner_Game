using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    float delay = 6f;
    public void LoadNextAfterAWhile()
    {
        Invoke("LoadNextLevel", delay);
    }

    public void LoadNextLevel()
    {
        Debug.Log("Next levela geldik");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}