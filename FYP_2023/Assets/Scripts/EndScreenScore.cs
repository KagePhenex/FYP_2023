using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private TextMeshProUGUI endScoreTxt;
    [SerializeField] private TextMeshProUGUI endHighScoreTxt;

    // Update is called once per frame
    void Update()
    {
        endScoreTxt.text = scoreTxt.text;
        endHighScoreTxt.text = highScoreTxt.text;
    }
}
