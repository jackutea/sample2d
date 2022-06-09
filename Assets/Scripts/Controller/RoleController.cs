using System;
using UnityEngine;
using Sample2D.Facades;

namespace Sample2D.Controller {

    public class RoleController {

        public RoleController() {}

        public void Ctor() {

        }

        public void Init() {

        }

        // 物理发生
        public void FixedTick(float fixedDeltaTime) {

            // 角色移动
            RoleEntity role = AllRepo.RoleEntity;
            if (role != null) {
                
                PlayerEntity player = AllRepo.PlayerEntity;
                
                Vector2 moveAxis = player.moveAxis;
                role.Move(moveAxis);

                float jumpAxis = player.jumpAxis;
                role.Jump(jumpAxis);

                role.Falling(jumpAxis, fixedDeltaTime);

            }

        }

        public void Tick() {

            // 生成角色
            if (AllEventCenter.IsSpawnRole) {
                AllEventCenter.SetIsSpawnRole(false);
                SpawnRole();
            }

        }

        public void LateTick() {

        }

        public void TearDown() {

        }

        // LOCAL EVENT
        void SpawnRole() {

            // 生成角色
            RoleEntity prefab = AllAssets.WorldAssets.GetRolePrefab();
            RoleEntity role = GameObject.Instantiate(prefab);

            // 设置坐标
            MapEntity mapEntity = AllRepo.MapEntity;
            Vector2 spawnPoint = mapEntity.GetRoleSpawnPoint();
            role.transform.position = spawnPoint;

            // 相机跟随角色
            CameraEntity cameraEntity = AllRepo.CameraEntity;
            cameraEntity.SetFollow(role.transform);

            // 缓存起来
            AllRepo.SetRoleEntity(role);

        }

    }

}