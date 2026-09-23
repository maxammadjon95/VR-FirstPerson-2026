using Assets.Scripts.FirstPersonController;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scratch.FirstPerson
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerMovement _movement;
        [SerializeField] PlayerJump _jump;
        [SerializeField] PlayerLook _look;
        [SerializeField] DoorOpener _doorOpener;

        public bool RunKeyPressed { get; private set; }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var keyboard = Keyboard.current;
            var mouse = Mouse.current;
            if (keyboard == null || mouse == null) return;

            Vector2 moveInput = Vector2.zero;
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) moveInput.y += 1f;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) moveInput.y -= 1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveInput.x += 1f;
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveInput.x -= 1f;
            moveInput.Normalize();

            RunKeyPressed = keyboard.shiftKey.isPressed;

            Vector2 lookInput = mouse.delta.ReadValue();

            _jump.Tick(Time.deltaTime);
            if (keyboard.spaceKey.wasPressedThisFrame) _jump.Jump();

            _movement.Move(moveInput, Time.deltaTime);
            _look.Look(lookInput, Time.deltaTime);

            if (keyboard.fKey.wasPressedThisFrame) _doorOpener.OpenOrCloseDoor();
        }
    }
}
