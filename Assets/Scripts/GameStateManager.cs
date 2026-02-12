using UnityEngine;

public enum GameState
{
    None, 
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Settings,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public UIManager uiManager;
    
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
        if(currentState == newState) return;

        previousState = currentState;
        currentState = newState;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        Time.timeScale = 1f;
        
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
                uiManager.ShowMainMenu();
                break;

            case GameState.Gameplay:
                Debug.Log("GameState changed to Gameplay");
                uiManager.ShowGamePlay();
                break;

            case GameState.Paused:
                Debug.Log("GameState changed to Paused");
                uiManager.ShowPaused();
                Time.timeScale = 0f;
                break;

            case GameState.Settings:
                Debug.Log("GameState changed to Settings");
                uiManager.ShowSettings();
                break;

            case GameState.GameOver:
                Debug.Log("GameState changed to GameOver");
                uiManager.ShowGameOver();
                break;

            default:
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();

        if (Input.GetKeyDown(KeyCode.Space)) SetState(GameState.GameOver);
    }

    public void TogglePause()
    {
        if(currentState == GameState.Paused) SetState(GameState.Gameplay);

        else if(currentState == GameState.Gameplay) SetState(GameState.Paused);
    }

    public void GoToMainMenu()
    {
        SetState(GameState.MainMenu);
    }

    public void GoToGameplay()
    {
        SetState(GameState.Gameplay);
    }

    public void GoToSettings()
    {
        SetState(GameState.Settings);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void GoToPrevious()
    {
        SetState(previousState);
    }
}