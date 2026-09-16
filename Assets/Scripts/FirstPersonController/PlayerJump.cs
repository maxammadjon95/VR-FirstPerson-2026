using UnityEngine;

namespace Scratch.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] CharacterController _controller;
        [SerializeField] float _jumpHeight = 1.5f;
        [SerializeField] float _gravity = -9.81f;

        private float _verticalVelocity;

        public float VerticalVelocity => _verticalVelocity;

        public void Tick(float deltaTime)
        {
            if (_controller.isGrounded && _verticalVelocity < 0f)
                _verticalVelocity = -2f; 

            _verticalVelocity += _gravity * deltaTime;
        }

        public void Jump()
        {
            if (!_controller.isGrounded) return;
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }
}
