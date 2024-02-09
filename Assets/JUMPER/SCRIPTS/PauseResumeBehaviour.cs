using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseResumeBehaviour : MonoBehaviour
{

    public TMP_Text textBtn;

    public static bool isStart = true;

    public void toggleStartResume()
    {
        if(isStart)
        {
            PauseGame();
            isStart = false;
        }
        else
        {
            ResumeGame();
            isStart = true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        textBtn.text = "Reprendre";
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        textBtn.text = "Pause";
    }
}
