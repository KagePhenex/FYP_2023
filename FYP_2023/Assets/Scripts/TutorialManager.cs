using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialPgs; //Tutorial page array
    [SerializeField] private GameObject tutorialCanvas;
    private int currentPage;

    // Update is called once per frame
    void OnEnable()
    {
        foreach(GameObject i in tutorialPgs)
        {
            i.SetActive(false);
        }
        tutorialPgs[0].SetActive(true);
        currentPage = 0;
    }
    public void closeTutorial()
    {
        tutorialCanvas.SetActive(false);
    }
    public void nextPg()
    {
        if(currentPage + 1 < tutorialPgs.Length)
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[currentPage + 1].SetActive(true);
            currentPage += 1; 
        }
        else
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[0].SetActive(true);
            currentPage = 0;
        }
    }

    public void previousPg()
    {
        if (currentPage - 1 >= 0)
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[currentPage - 1].SetActive(true);
            currentPage -= 1;
        }
        else
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[tutorialPgs.Length - 1].SetActive(true);
            currentPage = tutorialPgs.Length - 1;
        }
    }
}
