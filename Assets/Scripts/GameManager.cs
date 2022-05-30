using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject onPlay;
    public GameObject onPause;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
            onPause.SetActive(true);
            onPlay.SetActive(false);
        }
    }

    public void LoadGameScene(int _sceneID)
    {
   		//add the scene ID in the unity editor to load a particular scene
    	SceneManager.LoadScene(_sceneID);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
    	//quit the game
    	Application.Quit();
    }
}
