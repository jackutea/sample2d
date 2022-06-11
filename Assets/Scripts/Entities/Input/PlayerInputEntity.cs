using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample2D {

    public class PlayerInputEntity {

        PlayerInputAction inputActions;

        public event Action<Vector2> OnMoveHandle;
        public event Action<float> OnJumpHandle;
        public event Action<bool> OnMeleeHandle;

        public PlayerInputEntity() {

            inputActions = new PlayerInputAction();

            inputActions.Player.Move.started += OnMove; // 按下
            inputActions.Player.Move.performed += OnMove; // 按住
            inputActions.Player.Move.canceled += OnMove; // 弹起

            inputActions.Player.Jump.started += OnJump;
            inputActions.Player.Jump.canceled += OnJump;

            inputActions.Player.Melee.started += OnMelee;
            inputActions.Player.Melee.canceled += OnMelee;

            inputActions.Enable();

        }

        void OnMove(InputAction.CallbackContext ctx) {
            Vector2 moveAxis = ctx.ReadValue<Vector2>();
            OnMoveHandle.Invoke(moveAxis);
        }

        void OnJump(InputAction.CallbackContext ctx) {
            float jumpAxis = ctx.ReadValue<float>();
            OnJumpHandle.Invoke(jumpAxis);
        }

        void OnMelee(InputAction.CallbackContext ctx) {
            bool isTriggerMelee = ctx.ReadValueAsButton();
            OnMeleeHandle.Invoke(isTriggerMelee);
        }

    }

}