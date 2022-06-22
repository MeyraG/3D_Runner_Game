using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject _levelCompUI;
    
    [SerializeField] private float _nextLevelDelay = 1f;
    [SerializeField] private float _restartGameDelay = 1f;
    
    private bool _gameHasEnded;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void LevelCompleted()
    {
        _levelCompUI.SetActive(true);
        StartCoroutine(LoadNextLevel());
    }

    public void LevelFailed()
    {
        if (!_gameHasEnded)
        {
            _gameHasEnded = true;
            Debug.LogWarning("Game Over!!!"); 
            
            Invoke(nameof(RestartLevel), _restartGameDelay);         
        }     
    }
    
    private void RestartLevel()
    {
        Debug.Log("Restarting Level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(_nextLevelDelay);
        
        Debug.Log("Next Level Loading...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}