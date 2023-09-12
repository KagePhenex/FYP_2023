using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialPgs; //Tutorial page array
    [SerializeField] private GameObject tutorialCanvas; //Tutorial canvas
    private int currentPage; //Current page int

    // Update is called once per frame
    void OnEnable()
    {
        //Set all pages to false
        foreach(GameObject i in tutorialPgs)
        {
            i.SetActive(false);
        }
        tutorialPgs[0].SetActive(true); //Set 1st page to true
        currentPage = 0; //Set 1st page int
    }
    //Close Tutorial canvas
    public void closeTutorial()
    {
        tutorialCanvas.SetActive(false);
    }
    //Next Page
    public void nextPg()
    {
        //If not the last page, go to next page
        if(currentPage + 1 < tutorialPgs.Length)
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[currentPage + 1].SetActive(true);
            currentPage += 1; 
        }
        else //If last page, go to first page
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[0].SetActive(true);
            currentPage = 0;
        }
    }
    //Previous Page
    public void previousPg()
    {
        //If not the first page, go to previous page
        if (currentPage - 1 >= 0)
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[currentPage - 1].SetActive(true);
            currentPage -= 1;
        }
        else //If first page, go to last page
        {
            tutorialPgs[currentPage].SetActive(false);
            tutorialPgs[tutorialPgs.Length - 1].SetActive(true);
            currentPage = tutorialPgs.Length - 1;
        }
    }
}
