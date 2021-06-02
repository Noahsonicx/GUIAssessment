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
        FindObjectOfType<KeyBinding>().Save();
        SceneManager.LoadScene("PauseMenu");
    }
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGame");
    }
    public void SaveGame()
    {
        SceneManager.LoadScene("SaveGame");
    }
}
