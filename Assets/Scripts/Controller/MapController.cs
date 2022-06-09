using System;
using UnityEngine;
using Sample2D.Facades;

namespace Sample2D.Controller {

    public class MapController {

        public MapController() { }

        public void Ctor() {

        }

        public void Init() {

        }

        public void Tick() {

            if (AllEventCenter.IsStartGame) {
                AllEventCenter.SetIsStartGame(false);
                // 开始游戏按钮按下之后
                SpawnMap();
            }

        }

        public void FixedTick() {

        }

        public void LateTick() {

        }

        public void TearDown() {

        }

        // LOCAL EVENT
        void SpawnMap() {

            // 生成地图
            MapEntity prefab = AllAssets.WorldAssets.GetMapPrefab();
            MapEntity map = GameObject.Instantiate(prefab);
            AllRepo.SetMapEntity(map);

            // 让相机边缘 设置为地图的边缘
            // 让相机跟随
            PolygonCollider2D confiner = map.GetConfiner();
            CameraEntity cameraEntity = AllRepo.CameraEntity;
            cameraEntity.SetConfiner(confiner);

            // 生成角色
            AllEventCenter.SetIsSpawnRole(true);

        }

    }

}