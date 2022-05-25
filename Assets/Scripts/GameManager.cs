using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float delay = 4f;
    public Transform player;

    public GameObject levelCompUI;

    public LevelComplete levelComplete;


    void Start()
    {
        levelComplete = GetComponent<LevelComplete>();
    }


    public void LevelComplete()
    {
        levelCompUI.SetActive(true);
        levelComplete.LoadNextAfterAWhile();
    }



    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
           
            Invoke("Restart", delay);         
        }     
    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}