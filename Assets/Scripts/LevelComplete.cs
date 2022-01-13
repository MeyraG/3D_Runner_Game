using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public float delay = 4f;
    public void LoadNextAfterAWhile()
    {
        Invoke("LoadNextLevel", delay);
    }
    public void LoadNextLevel()
    {
        Debug.Log("NExt levela geldik");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}