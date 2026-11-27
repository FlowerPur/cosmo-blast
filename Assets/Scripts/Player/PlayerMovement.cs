using UnityEngine;

namespace CosmoBlast.Player
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;
        private Rect _touchArea;
        private Camera _camera;
        private Vector2Int _screenSize;

        private void Awake()
        {
            _playerInputActions = new();
            _camera = Camera.main;

            RefreshTouchArea();
        }

        private void OnEnable() => _playerInputActions.Enable();

        private void OnDisable() => _playerInputActions.Disable();

        private void Update()
        {
            RefreshTouchArea();

            if (!TryGetMovementTouchPosition(out var touchPosition)) return;

            MoveTo(GetTargetPosition(touchPosition));
        }

        private void RefreshTouchArea()
        {
            Vector2Int currentScreenSize = new(Screen.width, Screen.height);

            if (_screenSize == currentScreenSize) return;

            _screenSize = currentScreenSize;

            _touchArea = new(0, 0, _screenSize.x, _screenSize.y * 0.5f);
        }

        private bool TryGetMovementTouchPosition(out Vector2 touchPosition)
        {
            touchPosition = default;

            if (!_playerInputActions.Player.TouchPress.IsPressed()) return false;

            touchPosition = _playerInputActions.Player.TouchPosition.ReadValue<Vector2>();

            return _touchArea.Contains(touchPosition);
        }

        private Vector3 GetTargetPosition(Vector2 touchPosition)
        {
            var objectScreenPosition = _camera.WorldToScreenPoint(transform.position);

            var worldPosition = _camera.ScreenToWorldPoint(
                new Vector3(touchPosition.x, objectScreenPosition.y, objectScreenPosition.z));

            return new(worldPosition.x, transform.position.y, transform.position.z);
        }

        private void MoveTo(Vector2 targetPosition) =>
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                10f * Time.deltaTime
            );
    }
}
