using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager: MonoBehaviour
{
    [SerializeField] private GameObject tutorialCanvas;
    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void DisplayTutorial()
    {
        tutorialCanvas.SetActive(true);
    }
}
