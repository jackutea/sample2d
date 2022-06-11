using System;
using UnityEngine;

namespace Sample2D {

    public class MapMonsterSpawnComponent : MonoBehaviour {

        // 只生成一种怪物
        public int monsterID;
        public int count;
        public Vector2 position;

#if UNITY_EDITOR
        [ContextMenu("SetSpawnPosition")]
        void SetPosition() {
            position = transform.position;
        }
#endif

    }

}