using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sample2D.UIRenderer;
using Sample2D.Facades;
using Sample2D.Controller;

namespace Sample2D.Entry {

    // 主入口
    public class AppEntry : MonoBehaviour {

        // CONTROLLERS
        MainController mainController;
        MapController mapController;
        RoleController roleController;
        MonsterController monsterController;

        // STATE
        bool isInit;
        bool isTearDown;

        // TODO: UI 暂时放这里
        public Canvas canvas;
        public UIPageLogin uiPageLoginPrefab;
        UIPageLogin uiPageLogin;

        // 第1执行的
        void Awake() {

            // 初始化
            isInit = false;
            isTearDown = false;

            // 帧率
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            MonoBehaviour.DontDestroyOnLoad(gameObject);

            // ==== FACADES ====
            // - Assets
            WorldAssets worldAssets = GetComponentInChildren<WorldAssets>();
            ActionorAssets actionorAssets = GetComponentInChildren<ActionorAssets>();
            AllAssets.SetWorldAssets(worldAssets);
            AllAssets.SetActionorAssets(actionorAssets);

            // - EventCenter
            AllEventCenter.Ctor();

            // - Repo
            PlayerInputEntity playerInputEntity = new PlayerInputEntity();
            PlayerEntity playerEntity = new PlayerEntity();
            CameraEntity cameraEntity = transform.GetComponentInChildren<CameraEntity>();
            AllRepo.SetInputEntity(playerInputEntity);
            AllRepo.SetPlayerEntity(playerEntity);
            AllRepo.SetCameraEntity(cameraEntity);

            // ==== CONTROLLER ====
            // ---- CTOR ----
            mainController = new MainController();
            mainController.Ctor();

            mapController = new MapController();
            mapController.Ctor();

            roleController = new RoleController();
            roleController.Ctor();

            monsterController = new MonsterController();
            monsterController.Ctor();

            // ---- INIT ----
            mainController.Init();
            mapController.Init();
            roleController.Init();
            monsterController.Init();

            // UI 开始游戏按钮
            uiPageLogin = GameObject.Instantiate(uiPageLoginPrefab, canvas.transform);
            uiPageLogin.OnStartGameHandle += OnStartGame;

            isInit = true;

        }

        // 第2执行的
        void Start() {

        }

        // 第3执行的, 有时会多执行几次, 有时少执行几次
        void FixedUpdate() {

            if (!isInit) {
                return;
            }

            float fixedDeltaTime = Time.fixedDeltaTime;
            mapController.FixedTick();
            roleController.FixedTick(fixedDeltaTime);
            monsterController.FixedTick();

        }

        // FixedUpdate 与 Update 区别
        // FixedUpdate 用于物理
        // 定时执行, 比如电脑卡了 10秒, FixedUpdate 0.1秒执行一次, 在Update前100次
        // 速度为1, 前方1有墙, 1 * 0.1 = 0.1, 执行第10次碰撞

        // Update
        // 电脑卡了10秒, Update 执行一次 10 -> deltaTime
        // 速度为1, 前方1有墙, 1 * 100 = 100, 穿墙了

        // 第3执行的
        void Update() {

            if (!isInit) {
                return;
            }

            // 保证顺序的
            mapController.Tick();
            roleController.Tick();
            monsterController.Tick();

        }

        // 第4执行的
        void LateUpdate() {

            if (!isInit) {
                return;
            }

            mapController.LateTick();
            roleController.LateTick();

        }

        // 退出(手机端直接切断)
        void OnApplicationQuit() {
            TearDown();
        }

        // 手机端有时不触发
        void OnDestroy() {
            TearDown();
        }

        // 销毁
        void TearDown() {
            
            if (isTearDown) {
                return;
            }

            isTearDown = true;

            roleController.TearDown();
            mapController.TearDown();

        }

        // UI EVENT
        void OnStartGame() {

            // 删除 UI
            GameObject.Destroy(uiPageLogin.gameObject);

            Debug.Log("OnStartGame");

            // 选择关卡
            // 存读档
            // ... Args 参数 MapController 生成地图

            // MapEntity prefab = AllAssets.WorldAssets.GetMapPrefab();
            // prefab = GameObject.Instantiate(prefab);

            AllEventCenter.SetIsStartGame(true);

        }
        
    }

}

