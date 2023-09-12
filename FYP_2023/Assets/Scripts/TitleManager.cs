using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager: MonoBehaviour
{
    [SerializeField] private GameObject tutorialCanvas; //Tutorial Canvas
    //Load next scene to start game
    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }
    //Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
    //Display Tutorial canvas
    public void DisplayTutorial()
    {
        tutorialCanvas.SetActive(true);
    }
}
