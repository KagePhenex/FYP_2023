using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] private GameObject gameOverCanvas, pauseCanvas; //Game Over and Pause Canvas
    [SerializeField] private AudioSource bgmManager; //Background Music Audio Source

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f; //Default time scale
    }
    private void Update()
    {
        //Pause game with esc key
        if(Input.GetKeyDown("escape"))
        {
            Pause();
        }
    }
    //Pause Game
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }
    //Unpause/Play Game
    public void Play()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }
    //Display Game Over Canvas
    public void GameOver()
    {
        bgmManager.Stop();
        SFXManager.instance.playGameOver();
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    //Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Return to Home/Title Screen
    public void HomeScreen(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
}
