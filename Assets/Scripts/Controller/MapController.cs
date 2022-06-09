using System;
using UnityEngine;
using Sample2D.Facades;

namespace Sample2D.Controller {

    public class MapController {

        public MapController() {}

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

            // 生成角色
            AllEventCenter.SetIsSpawnRole(true);

        }

    }

}