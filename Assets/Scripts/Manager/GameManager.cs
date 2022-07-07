using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Win }

public class GameManager : Singleton<GameManager>
{
    private GameState gameState;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;
    }

    public void ChangeGameState(GameState gameState)
    {
        this.gameState = gameState;
        
        switch (gameState)
        {
            case GameState.Win:
                UIManager.Ins.PopNextLevelUI();
                break;
            default:
                Debug.LogWarning("Not valid game state");
                break;
        }
    }

    public bool IsState(GameState gameState)
    {
        return this.gameState == gameState;
    }

    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
