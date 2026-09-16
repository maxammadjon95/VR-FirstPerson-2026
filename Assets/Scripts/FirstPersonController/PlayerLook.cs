using UnityEngine;

namespace Scratch.FirstPerson
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] Transform _cameraTransform;
        [SerializeField] float _mouseSensitivity = 0.1f;
        [SerializeField] float _minPitch = -80f;
        [SerializeField] float _maxPitch = 80f;

        private float _pitch;

        public void Look(Vector2 input, float deltaTime)
        {
            transform.Rotate(Vector3.up * input.x * _mouseSensitivity);

            _pitch = Mathf.Clamp(_pitch - input.y * _mouseSensitivity, _minPitch, _maxPitch);
            _cameraTransform.localEulerAngles = new Vector3(_pitch, 0f, 0f);
        }
    }
}
