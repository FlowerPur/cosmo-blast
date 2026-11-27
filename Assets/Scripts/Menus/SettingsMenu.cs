using UnityEngine;
using UnityEngine.UI;

namespace CosmoBlast.Menus
{
    public sealed class SettingsMenu : Menu
    {
        [SerializeField] private Button _backButton;

        [SerializeField] private MainMenu _mainMenu;

        private void OnEnable() => _backButton.onClick.AddListener(OnBackButtonClick);

        private void OnDisable() => _backButton.onClick.RemoveListener(OnBackButtonClick);

        private void OnBackButtonClick() => SwitchTo(_mainMenu);
    }
}
