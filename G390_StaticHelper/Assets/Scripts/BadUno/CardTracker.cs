using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTracker : MonoBehaviour
{
    public Text handTrackerText;
    public Text playStackTrackerText;
    public Text winText;

    private void Start()
    {
        winText.text = "";
    }

    public void UpdatePlayerHandText(string text) => handTrackerText.text = text;
    public void UpdatePlayStackText(string text) => playStackTrackerText.text = text;
    public void UpdateWinText() => winText.text = "You won somehow?";
    public void UpdateAllText(string playerHandText, string stackText)
    {
        handTrackerText.text = playerHandText;
        playStackTrackerText.text = stackText;
    }

}
