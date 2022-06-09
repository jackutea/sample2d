using System;

namespace Sample2D.Facades {

    public static class AllRepo {

        // 输入
        static PlayerInputEntity inputEntity;
        public static PlayerInputEntity InputEntity => inputEntity;
        public static void SetInputEntity(PlayerInputEntity entity) => inputEntity = entity;

        // 主相机
        static CameraEntity cameraEntity;
        public static CameraEntity CameraEntity => cameraEntity;
        public static void SetCameraEntity(CameraEntity cam) => cameraEntity = cam;

        // 玩家
        static PlayerEntity playerEntity;
        public static PlayerEntity PlayerEntity => playerEntity;
        public static void SetPlayerEntity(PlayerEntity entity) => playerEntity = entity;

        // 地图
        static MapEntity mapEntity;
        public static MapEntity MapEntity => mapEntity;
        public static void SetMapEntity(MapEntity entity) => mapEntity = entity;

        // 角色
        static RoleEntity roleEntity;
        public static RoleEntity RoleEntity => roleEntity;
        public static void SetRoleEntity(RoleEntity entity) => roleEntity = entity;

    }
}