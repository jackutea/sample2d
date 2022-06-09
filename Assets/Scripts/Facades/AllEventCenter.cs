using System;

namespace Sample2D.Facades {

    public static class AllEventCenter {

        static bool isStartGame;
        public static bool IsStartGame => isStartGame;
        public static void SetIsStartGame(bool isStart) => isStartGame = isStart;

        static bool isSpawnRole;
        public static bool IsSpawnRole => isSpawnRole;
        public static void SetIsSpawnRole(bool isSpawn) => isSpawnRole = isSpawn;

    }

}