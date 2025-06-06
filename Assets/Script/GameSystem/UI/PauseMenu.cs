using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private GameObject settingsMenu;
    
    private UIDocument pauseMenuDocument;
    private Button resumeButton;
    private Button settingsButton;
    private Button mainMenuButton;
    [SerializeField] private AudioSource audioSource;
    
    private void Awake()
    {
        pauseMenuDocument = GetComponent<UIDocument>();
    }
    
    private void OnEnable()
    {
        var root = pauseMenuDocument.rootVisualElement;
        
        resumeButton = root.Q<Button>("ResumeButton");
        settingsButton = root.Q<Button>("SettingsButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");
        
        resumeButton.RegisterCallback<ClickEvent>(OnResumeClicked);
        settingsButton.RegisterCallback<ClickEvent>(OnSettingsClicked);
        mainMenuButton.RegisterCallback<ClickEvent>(OnMainMenuClicked);
    }
    
    private void OnDisable()
    {
        if (resumeButton != null)
            resumeButton.UnregisterCallback<ClickEvent>(OnResumeClicked);
            
        if (settingsButton != null)
            settingsButton.UnregisterCallback<ClickEvent>(OnSettingsClicked);
            
        if (mainMenuButton != null)
            mainMenuButton.UnregisterCallback<ClickEvent>(OnMainMenuClicked);
    }
    
    private void OnResumeClicked(ClickEvent evt)
    {
        if (audioSource != null)
            audioSource.Play();
            
        Resume();
    }
    
    private void OnSettingsClicked(ClickEvent evt)
    {
        if (audioSource != null)
            audioSource.Play();
            
        OpenSettings();
    }
    
    private void OnMainMenuClicked(ClickEvent evt)
    {
        if (audioSource != null)
            audioSource.Play();
        Time.timeScale=1;    
        Invoke("GoToMainMenu",0.5f);
    }
    
    private void Resume()
    {
        uiController.ResumeGame();
    }
    
    private void OpenSettings()
    {
        gameObject.SetActive(false);
        SettingsMenu settingsMenuComponent = settingsMenu.GetComponent<SettingsMenu>();
        settingsMenuComponent.OpenFromGame();
    }
    
    private void GoToMainMenu()
    {
        uiController.LoadMainMenu();
    }
}