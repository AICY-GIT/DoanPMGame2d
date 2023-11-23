using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ki : MonoBehaviour
{
    public TextMeshProUGUI PauseScore;
    public TextMeshProUGUI PlayScore;
    private int currentKilled = 0;

    private void Start()
    {
        PauseScore.text = "0";
        PlayScore.text = "0";
    }

    public void UpdateKilled()
    {

        currentKilled++;
        PauseScore.text = currentKilled.ToString();
        PlayScore.text = currentKilled.ToString();
    }
}
