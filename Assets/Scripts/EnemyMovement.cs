using UnityEngine;

public sealed class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Camera _camera;
    private Vector3 _targetPosition;

    private void Awake() => _camera = Camera.main;

    private void Start() => _targetPosition = GetTargetPosition();

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) <= 0.05f)
            _targetPosition = GetTargetPosition();

        MoveTo(_targetPosition);
    }

    private Vector3 GetTargetPosition()
    {
        var objectScreenPosition = _camera.WorldToScreenPoint(transform.position);

        var randomScreenPosition = new Vector3(
            Random.Range(0f, Screen.width),
            objectScreenPosition.y,
            objectScreenPosition.z);

        return new(
            _camera.ScreenToWorldPoint(randomScreenPosition).x,
            transform.position.y,
            transform.position.z
        );
    }

    private void MoveTo(Vector3 targetPosition) =>
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            _speed * Time.deltaTime
        );
}
