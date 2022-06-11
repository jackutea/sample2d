using System;
using System.Collections.Generic;

namespace Sample2D.Facades {

    public static class AllEventCenter {

        // 是否开始游戏
        static bool isStartGame;
        public static bool IsStartGame => isStartGame;
        public static void SetIsStartGame(bool isStart) => isStartGame = isStart;

        // 是否生成角色
        static bool isSpawnRole;
        public static bool IsSpawnRole => isSpawnRole;
        public static void SetIsSpawnRole(bool isSpawn) => isSpawnRole = isSpawn;

        // 生成怪物
        static Queue<MonsterSpawnEvent> monsterSpawnQueue;
        public static void EnqueueMonsterSpawn(MonsterSpawnEvent monsterSpawnEvent) => monsterSpawnQueue.Enqueue(monsterSpawnEvent);
        public static bool TryDequeueMonsterSpawn(out MonsterSpawnEvent monsterSpawnEvent) => monsterSpawnQueue.TryDequeue(out monsterSpawnEvent);

        public static void Ctor() {
            isStartGame = false;
            isSpawnRole = false;
            monsterSpawnQueue = new Queue<MonsterSpawnEvent>();
        }

    }

}