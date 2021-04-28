using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void PauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");
    }
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
