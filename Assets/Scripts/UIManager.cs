using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject gameoverUI;

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        settingsUI.SetActive(false);
        gameoverUI.SetActive(false);
    }
    
    public void ShowMainMenu()
    {
        HideAllUI();
        
        mainMenuUI.SetActive(true);
    }

    public void ShowGamePlay()
    {
        HideAllUI();

        gameplayUI.SetActive(true);
    }

    public void ShowPaused()
    {
        HideAllUI();

        gameplayUI.SetActive(true);
        pausedUI.SetActive(true);
    }

    public void ShowSettings()
    {
        HideAllUI();

        settingsUI.SetActive(true);
    }

    public void ShowGameOver()
    {
        HideAllUI();

        gameoverUI.SetActive(true);
    }
}
