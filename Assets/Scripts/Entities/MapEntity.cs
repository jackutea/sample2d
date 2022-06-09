using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Sample2D {

    public class MapEntity : MonoBehaviour {

        // ==== 背景 ====
        SpriteRenderer background;

        // ==== 地形 ====
        Tilemap tilemap;

        // ==== 相机 ====
        // - 相机边缘
        PolygonCollider2D cameraConfiner;
        // - 相机跟随点
        Transform cameraPoint;

        // ==== 生成点 ====
        Transform roleSpawnPoint;

        void Awake() {

            background = transform.GetChild(0).GetComponent<SpriteRenderer>();
            cameraConfiner = background.GetComponent<PolygonCollider2D>();
            tilemap = transform.GetChild(1).GetComponentInChildren<Tilemap>();
            cameraPoint = transform.GetChild(2);

            roleSpawnPoint = transform.GetChild(3);

            Debug.Assert(background != null);
            Debug.Assert(cameraConfiner != null);
            Debug.Assert(tilemap != null);
            Debug.Assert(cameraPoint != null);
            Debug.Assert(roleSpawnPoint != null);

        }

        public PolygonCollider2D GetConfiner() {
            return cameraConfiner;
        }

        public Transform GetCameraPoint() {
            return cameraPoint;
        }

        public Vector3 GetRoleSpawnPoint() {
            return roleSpawnPoint.position;
        }

    }

}