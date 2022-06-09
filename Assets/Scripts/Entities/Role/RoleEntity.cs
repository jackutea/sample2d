using System;
using UnityEngine;

namespace Sample2D {

    public class RoleEntity : MonoBehaviour {

        Rigidbody2D rb;

        float moveSpeed;
        float jumpForce;

        bool isJump;

        // COMPONENT
        RoleFootComponent footComponent;

        void Awake() {

            moveSpeed = 5.5f;
            jumpForce = 12f;

            isJump = false;

            rb = GetComponent<Rigidbody2D>();
            footComponent = GetComponentInChildren<RoleFootComponent>();
            footComponent.OnEnterGroundHandle += OnEnterGround;

            Debug.Assert(rb != null);

        }

        // ==== LOCOL MOTION ====
        // 左右移动
        public void Move(Vector2 moveAxis) {

            float vertical = rb.velocity.y;

            float xOffset = moveAxis.x; // 左 -1 , 左上 -0.71
            if (xOffset < 0) {
                xOffset = -1;
            } else if (xOffset > 0) {
                xOffset = 1;
            }

            rb.velocity = new Vector2(xOffset * moveSpeed, vertical);

        }

        // 跳
        public void Jump(float jumpAxis) {
            
            if (jumpAxis <= 0 || isJump) {
                return;
            }

            isJump = true;

            float horizontal = rb.velocity.x;

            rb.velocity = new Vector2(horizontal, jumpForce);

        }

        // ==== PHYSICS EVENT ====
        // 落地检测
        void OnEnterGround() {
            isJump = false;
        }

    }

}