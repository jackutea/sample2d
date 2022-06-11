using System;
using UnityEngine;
using Sample2D.Facades;

namespace Sample2D.Controller {

    public class MonsterController {

        public MonsterController() {}

        public void Ctor() {

        }

        public void Init() {

        }

        public void Tick() {

            while (AllEventCenter.TryDequeueMonsterSpawn(out MonsterSpawnEvent ev)) {

                // 1. Assets
                MonsterEntity prefab = AllAssets.WorldAssets.GetMonsterPrefab();

                // 2. 生成
                MonsterEntity monster = GameObject.Instantiate(prefab);
                monster.transform.position = ev.position;

                // 3. 根据ID信息, 配置怪物的参数: Mod Hp Def Atk Speed

            }

        }

        public void FixedTick() {

        }

        public void TearDown() {

        }

    }

}