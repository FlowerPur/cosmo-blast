using UnityEngine;
using UnityEngine.UI;

public sealed class SettingsMenu : Menu
{
    [SerializeField] private Button _backButton;

    [SerializeField] private GameObject _mainMenu;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackButtonClick);
    }

    private void OnBackButtonClick() => TransitionToMenu(_mainMenu);
}
