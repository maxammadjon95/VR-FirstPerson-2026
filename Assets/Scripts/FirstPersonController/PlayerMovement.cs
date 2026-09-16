using UnityEngine;

namespace Scratch.FirstPerson
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] CharacterController controller;
        [SerializeField] PlayerJump jump;
        [SerializeField] float moveSpeed = 5f;

        public void Move(Vector2 input, float deltaTime)
        {
            Vector3 horizontal = (transform.right * input.x + transform.forward * input.y) * moveSpeed;
            Vector3 velocity = horizontal + Vector3.up * jump.VerticalVelocity;
            controller.Move(velocity * deltaTime);
        }
    }
}
