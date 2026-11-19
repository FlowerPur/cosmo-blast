using UnityEngine;

public sealed class PickupMovement : MonoBehaviour
{
    private void Update() => transform.position += 1f * Time.deltaTime * Vector3.down;
}
