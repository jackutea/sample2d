using System;
using UnityEngine;
using Sample2D.Facades;

namespace Sample2D.Controller {

    public class RoleController {

        public RoleController() { }

        public void Ctor() {

        }

        public void Init() {

        }

        // 物理发生
        public void FixedTick(float fixedDeltaTime) {

            // 角色移动
            Locomotion(fixedDeltaTime);

            // 播技能
            ApplyActionor();

        }

        public void Tick() {

            // 生成角色
            SpawnRole();

            // 放技能
            CastSkillor();

        }

        public void LateTick() {

        }

        public void TearDown() {

        }

        // LOCAL EVENT
        void SpawnRole() {

            if (!AllEventCenter.IsSpawnRole) {
                return;
            }

            AllEventCenter.SetIsSpawnRole(false);

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

        // FIXED LOCOMOTION
        void Locomotion(float fixedDeltaTime) {

            // 角色移动
            RoleEntity role = AllRepo.RoleEntity;
            if (role == null) {
                return;
            }

            PlayerEntity player = AllRepo.PlayerEntity;

            Vector2 moveAxis = player.moveAxis;
            role.LocomotionMove(moveAxis);

            float jumpAxis = player.jumpAxis;
            role.LocomotionJump(jumpAxis);

            role.LocomotionFalling(jumpAxis, fixedDeltaTime);

        }

        // LOGIC
        void CastSkillor() {

            // 施放技能
            RoleEntity role = AllRepo.RoleEntity;
            if (role == null) {
                return;
            }

            PlayerEntity player = AllRepo.PlayerEntity;
            bool isTriggerMelee = player.isTriggerMelee;
            if (isTriggerMelee) {

                // TODO: 能否放技能

                // 后续蓄力
                player.isTriggerMelee = false;

                // 攻击
                // 1. 拿到 Asset - ActionorEntity Prefab
                const int ACITONOR_MELEE_TYPE_ID = 1;
                ActionorEntity meleeActionorPrefab = AllAssets.ActionorAssets.GetActionorPrefab(ACITONOR_MELEE_TYPE_ID);

                // 2. 生成
                ActionorEntity meleeActionor = GameObject.Instantiate(meleeActionorPrefab, role.Mesh.transform);
                meleeActionor.Ctor();
                role.ActionorComponent.currentActionor = meleeActionor;

                // 3. 禁用所有帧
                meleeActionor.DeactivateAllFrame();

                // 4. 禁用角色身体碰撞盒 
                role.PhysicsSetBodyBoxActivation(false);

                // 5. 播动画
                role.AnimPlayMelee();

            }

        }

        void ApplyActionor() {

            // 播技能
            RoleEntity role = AllRepo.RoleEntity;
            if (role == null) {
                return;
            }

            RoleActionorComponent actionorComponent = role.ActionorComponent;
            ActionorEntity actionor = actionorComponent.currentActionor;
            if (actionor != null) {

                // 获取当前帧, 并启用
                var curFrame = actionor.GetCurrent();
                curFrame.gameObject.SetActive(true);

                // 尝试播下一帧
                if (!actionor.TryMoveNext()) {

                    // 播完了
                    actionorComponent.currentActionor = null;

                    // 暂时移除, 以后再用对象池
                    GameObject.Destroy(actionor.gameObject);

                    // 启用角色自身Body碰撞盒 
                    role.PhysicsSetBodyBoxActivation(true);

                }

            }

        }

    }

}