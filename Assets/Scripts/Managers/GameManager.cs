using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("2 Copy of GameManager Exists!");
        }
        Instance = this;
    }
   
    public event Action<GameState> OnStateChange;
    public GameState gameState;

    void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }
    public void UpdateGameState(GameState _gamestate)
    {
        gameState = _gamestate;
        OnStateChange?.Invoke(_gamestate);
    }
}
public enum GameState
{
    MainMenu,
    Game,
    Paused,
    Death
}