using UnityEngine;

namespace Scratch.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] CharacterController _controller;
        [SerializeField] PlayerJump _jump;
        [SerializeField] float _moveSpeed = 5f;

        public void Move(Vector2 input, float deltaTime)
        {
            Vector3 horizontal = (transform.right * input.x + transform.forward * input.y) * _moveSpeed;
            Vector3 velocity = horizontal + Vector3.up * _jump.VerticalVelocity;
            _controller.Move(velocity * deltaTime);
        }
    }
}
