using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapperBehavour : MonoBehaviour
{
    public void PlayScene()
    {
        GameManagerBehaviour.point = 0;
        SceneManager.LoadScene("PlayScene");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
