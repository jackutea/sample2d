using System;
using UnityEngine;

namespace Sample2D {

    // 完整的动作
    public class ActionorEntity : MonoBehaviour {

        public int typeID;

        // 当前播到帧数
        int currentIndex;

        // 所有的帧
        ActionorFrameComponent[] frames;

        // 不是好习惯
        public void Ctor() {

            frames = GetComponentsInChildren<ActionorFrameComponent>();
            for (int i = 0; i < frames.Length; i++) {
                var frame = frames[i];
                frame.Ctor();
            }

            Debug.Assert(frames.Length > 0);

        }

        public ActionorFrameComponent GetCurrent() {
            return frames[currentIndex];
        }

        public void DeactivateAllFrame() {
            for (int i = 0; i < frames.Length; i += 1) {
                var frame = frames[i];
                frame.gameObject.SetActive(false);
            }
        }

        // 尝试播下一帧 
        public bool TryMoveNext() {
            currentIndex += 1;
            if (currentIndex > frames.Length - 1) {
                currentIndex = 0;
                return false;
            }
            return true;
        }

#if UNITY_EDITOR
        [ContextMenu("SetFrameIndexName")]
        void SetFrameIndexName() {
            for (int i = 0; i < transform.childCount; i += 1) {
                var child = transform.GetChild(i);
                child.name = "frame_" + i.ToString();
            }
            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif
    }

}