using UnityEngine;

namespace Scratch.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] CharacterController _controller;
        [SerializeField] PlayerController _player;
        [SerializeField] PlayerJump _jump;
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _runSpeed = 25f;

        public void Move(Vector2 input, float deltaTime)
        {
            float speed = _player.RunKeyPressed ? _runSpeed : _moveSpeed;
            Vector3 horizontal = (transform.right * input.x + transform.forward * input.y) * speed;
            Vector3 velocity = horizontal + Vector3.up * _jump.VerticalVelocity;
            _controller.Move(velocity * deltaTime);
        }
    }
}
