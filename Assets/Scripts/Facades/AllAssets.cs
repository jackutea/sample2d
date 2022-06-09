using System;

namespace Sample2D.Facades {

    public static class AllAssets {

        static WorldAssets worldAssets;
        public static WorldAssets WorldAssets => worldAssets;
        public static void SetWorldAssets(WorldAssets assets) => worldAssets = assets;

    }

}