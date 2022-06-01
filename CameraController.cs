using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _player;

    [SerializeField] [Range(0f, 1f)] private float _zoom = 0.2f;
    [SerializeField] private float _falloffDistance;

    private void LateUpdate() {
        var mousePos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            
        var pos = Vector3.Lerp(
            _player.position, 
            mousePos - (transform.position - _player.position), // "Parent" the mouse position to the player and not to the camera
            _zoom * _falloffDistance / Vector3.Distance(mousePos, _player.position)
        );
        pos.z = -10;

        transform.position = pos;
    }
}