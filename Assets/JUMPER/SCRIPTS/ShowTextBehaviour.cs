using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShowTextBehaviour : MonoBehaviour
{

    public TMP_Text gameStatus;
    public TMP_Text topScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManagerBehaviour.instance.gameStatus == "win")
        {
            setWinText();
        }
        else
        {
            setGameOverText();
        }
        
        setTopScoreText();
    }
    
    void setGameOverText()
    {
        gameStatus.text = "Game Over : " + GameManagerBehaviour.point;
    }

    void setWinText()
    {
        gameStatus.text = "WIN ! : " + GameManagerBehaviour.point;
    }

    void setTopScoreText()
    {
        Debug.Log(GameManagerBehaviour.instance.getScoreHistoric());
        topScoreText.text = string.Join("\n", GameManagerBehaviour.instance.getScoreHistoric());
    }
}
