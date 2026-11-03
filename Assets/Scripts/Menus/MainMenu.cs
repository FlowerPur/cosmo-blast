using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenu : Menu
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private SettingsMenu _settingsMenu;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnSettingsButtonClick() => SwitchTo(_settingsMenu);

    private void OnExitButtonClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
