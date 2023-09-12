using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScore : MonoBehaviour
{
    //UI Canvas Score and Highscore
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    //Game Over Canvas Score and Highscore
    [SerializeField] private TextMeshProUGUI endScoreTxt;
    [SerializeField] private TextMeshProUGUI endHighScoreTxt;

    // Update is called once per frame
    void Update()
    {
        //Update Game Over canvas score and highscore
        endScoreTxt.text = scoreTxt.text; 
        endHighScoreTxt.text = highScoreTxt.text;
    }
}
