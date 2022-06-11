using System;
using UnityEngine;
using Sample2D.Facades;

namespace Sample2D.Controller {

    public class MainController {

        public MainController() { }

        public void Ctor() {

        }

        public void Init() {
            PlayerInputEntity input = AllRepo.InputEntity;
            input.OnMoveHandle += OnMoveInput;
            input.OnJumpHandle += OnJumpInput;
            input.OnMeleeHandle += OnMeleeInput;
        }

        // LOCAL EVENT
        void OnMoveInput(Vector2 moveAxis) {

            PlayerEntity playerEntity = AllRepo.PlayerEntity;
            playerEntity.moveAxis = moveAxis;

        }

        void OnJumpInput(float jumpAxis) {
            PlayerEntity playerEntity = AllRepo.PlayerEntity;
            playerEntity.jumpAxis = jumpAxis;
        }

        void OnMeleeInput(bool isTriggerMelee) {
            PlayerEntity playerEntity = AllRepo.PlayerEntity;
            playerEntity.isTriggerMelee = isTriggerMelee;
        }

    }
}