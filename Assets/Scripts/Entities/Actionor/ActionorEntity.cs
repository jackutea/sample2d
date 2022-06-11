using System;
using UnityEngine;

namespace Sample2D {

    // 完整的动作
    public class ActionorEntity : MonoBehaviour {

        // 所有的帧
        ActionorFrameComponent[] frames;

        // 不是好习惯
        void Awake() {

            frames = GetComponentsInChildren<ActionorFrameComponent>();

            Debug.Assert(frames.Length > 0);

        }

    }

}