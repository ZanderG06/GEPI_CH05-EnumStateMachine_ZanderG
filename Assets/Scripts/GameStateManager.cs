using UnityEngine;

public enum GameState
{
    None, 
    Init,
    MainMenu,
    Gameplay,
    Paused
}

public class GameStateManager : MonoBehaviour
{
    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        previousState = currentState;
        currentState = newState;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        switch (newState)
        {
            case GameState.None:
                Debug.Log("Error :c");
                break;
            
            case GameState.Init:
                Debug.Log("GameState changed to Init");
                SetState(GameState.MainMenu);
                break;
            
            case GameState.MainMenu:
                Debug.Log("GameState changed to MainMenu");
                break;

            case GameState.Gameplay:
                Debug.Log("GameState changed to Gameplay");
                break;

            case GameState.Paused:
                Debug.Log("GameState changed to Paused");
                break;

            default:
                break;
        }
    }
}