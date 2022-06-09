using System;
using UnityEngine;

namespace Sample2D {

    // 角色脚底组件
    public class RoleFootComponent : MonoBehaviour {

        public event Action OnEnterGroundHandle;

        // 关键词: MonoBehaviour 生命周期
        void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Ground")) {
                OnEnterGroundHandle.Invoke();
            }
        }

    }

}