using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{

    public static GameManagerBehaviour instance = null;

    public static float getSpeed()
    {
        return instance.basicGameSpeed;
    }

    public float basicGameSpeed = 1.0f;
    public float INCREMENT = 0.005f;
    public float MAX_SPEED = 7;

    public static int point = 0;

    public string gameStatus = "loose";
    public BossBehaviour bossBehaviour;
    public BulletBehaviour bulletBehaviour;

    private void Awake()
    {
        
        StartCoroutine(incrementPoint());

    }

    // Start is called before the first frame update
    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        
        setCurrentPlayerName(InputBehaviour.choseUserName);
        userLabel.text = currentPlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        incrementSpeed();
        checkIfSwitchLight();

        if(bossBehaviour == null) { 
            endGame();
        }
    }

    void incrementSpeed()
    {
        if(basicGameSpeed < MAX_SPEED)
        {
            basicGameSpeed += INCREMENT * Time.deltaTime;
        }   
    }

    public void endGame()
    {
        if(gameStatus == "win")
        {
            point += 300;
        }

        saveScore(currentPlayerName, point);
        // Comment donner cette variable dans l'autre scène ??
        SceneManager.LoadScene("GameOverScene");    
    }


    // Coroutine pour les points
    public string currentPlayerName = "Inconnu";

    public TMP_Text pointCounter;
    public IEnumerator incrementPoint()
    {
        while (true)
        {
            point += 1;
            pointCounter.text = "Points : " + point;
            yield return new WaitForSeconds(0.1f);
        }   
    }

    // -- File top score management --
    public TMP_Text userLabel;
    public string fileName = "score.csv";
    public string separator = ";";
    public int limitScore = 6;
    public void saveScore(string sName, int sScore)
    {
        if(sName == null || sName == "")
        {
            sName = "Inconnu";
        }

        File.AppendAllText(fileName, new ScoreEntity(sName, sScore).getCSVFormat(separator) + "\n", Encoding.UTF8);
    }


    public List<ScoreEntity> getScoreHistoric()
    {
        List<ScoreEntity > scoreList = new List<ScoreEntity>();
        foreach (string readLine in File.ReadLines(fileName, Encoding.UTF8))
        {
            scoreList.Add(new ScoreEntity(readLine, separator));
        }

        scoreList.Sort(new ScoreEntityComparer());

        List<ScoreEntity> returnedScoreList = new List<ScoreEntity>();
        int count = 0;
        foreach(ScoreEntity score in scoreList)
        {
            returnedScoreList.Add(score);
            count++;

            if(count >= limitScore)
            {
                break;
            }
        }


        return returnedScoreList;
    }

    public string getScoreHistoric2String()
    {
        string scores = "";
        foreach(ScoreEntity scoreEntity in getScoreHistoric())
        {
            scores += scoreEntity.ToString() + "\n";
        }

        return scores;
    }

    public void setCurrentPlayerName(string playerName)
    {
        currentPlayerName = playerName;
        userLabel.text = currentPlayerName;
    }

    // -- DAY NIGHT Manager --
    public int pointInterval = 100;
    public bool isNight = false;

    public Color hexNight = new Color(146, 146, 146);
    public Color hexLight = new Color(255, 255, 255);

    public List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    
    public void switchLight()
    {
        foreach(SpriteRenderer renderer in renderers)
        {
            if(isNight)
            {
                renderer.color = hexLight;
            }
            else
            {
                renderer.color = hexNight;
            }
        }
        
        isNight = !isNight;
    }

    public void checkIfSwitchLight()
    {
        if(point%pointInterval == 0)
        {
            switchLight();
        }
    }
}
