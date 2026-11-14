using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    private Rect _rect;
    private Camera _camera;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _rect = new Rect(0, 0, Screen.width, Screen.height * 0.5f);
        _camera = Camera.main;
    }

    private void OnEnable() => _playerInputActions.Enable();

    private void OnDisable() => _playerInputActions.Disable();

    private void Update()
    {
        if (!_playerInputActions.Player.TouchPress.IsPressed()) return;

        Vector2 touchPosition = _playerInputActions.Player.TouchPosition.ReadValue<Vector2>();

        if (!_rect.Contains(touchPosition)) return;

        Vector3 objectScreenPosition = _camera.WorldToScreenPoint(transform.position);

        var worldPosition = _camera.ScreenToWorldPoint(
            new Vector3(touchPosition.x, objectScreenPosition.y, objectScreenPosition.z));

        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(worldPosition.x, transform.position.y, transform.position.z),
            10f * Time.deltaTime
        );
    }
}
