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
        public void FixedTick() {

        }

        public void Tick() {

            // 生成角色
            if (AllEventCenter.IsSpawnRole) {
                AllEventCenter.SetIsSpawnRole(false);
                SpawnRole();
            }

            // 输入控制
            RoleEntity role = AllRepo.RoleEntity;
            if (role != null) {
                
                PlayerEntity player = AllRepo.PlayerEntity;
                
                Vector2 moveAxis = player.moveAxis;
                role.Move(moveAxis);

                float jumpAxis = player.jumpAxis;
                role.Jump(jumpAxis);

            }

        }

        public void LateTick() {

        }

        public void TearDown() {

        }

        // LOCAL EVENT
        void SpawnRole() {
            RoleEntity prefab = AllAssets.WorldAssets.GetRolePrefab();
            RoleEntity role = GameObject.Instantiate(prefab);
            AllRepo.SetRoleEntity(role);
        }

    }

}