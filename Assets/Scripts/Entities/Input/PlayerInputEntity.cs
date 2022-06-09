using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample2D {

    public class PlayerInputEntity {

        PlayerInputAction inputActions;

        public event Action<Vector2> OnMoveHandle;
        public event Action<float> OnJumpHandle;

        public PlayerInputEntity() {

            inputActions = new PlayerInputAction();

            inputActions.Player.Move.started += OnMove; // 按下
            inputActions.Player.Move.performed += OnMove; // 按住
            inputActions.Player.Move.canceled += OnMove; // 弹起

            inputActions.Player.Jump.started += OnJump;
            inputActions.Player.Jump.canceled += OnJump;

            inputActions.Enable();

        }

        void OnMove(InputAction.CallbackContext context) {
            Vector2 moveAxis = context.ReadValue<Vector2>();
            OnMoveHandle.Invoke(moveAxis);
        }

        void OnJump(InputAction.CallbackContext context) {
            float jumpAxis = context.ReadValue<float>();
            OnJumpHandle.Invoke(jumpAxis);
        }

    }

}