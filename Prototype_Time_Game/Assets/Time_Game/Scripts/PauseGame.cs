using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menuPause;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.Instance.currentGameState == GameManager.GameStatus.gameRunning)
            {
                PauseMenu();
            }
            else if(GameManager.Instance.currentGameState == GameManager.GameStatus.gamePaused)
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        GameManager.Instance.currentGameState = GameManager.GameStatus.gameRunning;
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }
    public void PauseMenu()
    {
        GameManager.Instance.currentGameState = GameManager.GameStatus.gamePaused;
        Time.timeScale = 0f;
        menuPause.SetActive(true);
    }
}
