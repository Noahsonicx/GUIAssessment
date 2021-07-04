using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    /*
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    
    public void PauseMenu()
    {
        FindObjectOfType<KeyBinding>().Save();
        SceneManager.LoadScene("PauseMenu");
    }
    */
    public void GameScene()
    {
        FindObjectOfType<KeyBinding>().Save();
        SceneManager.LoadScene("GameScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGame");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void SaveGame()
    {
        SceneManager.LoadScene("SaveGame");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
