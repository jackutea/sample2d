using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sample2D {

    public class ActionorAssets : MonoBehaviour {

        [SerializeField] ActionorEntity meleePrefab;

        // 临时的
        public ActionorEntity GetActionorPrefab(int typeID) {
            switch (typeID) {
                case 1:
                    return meleePrefab;
                default:
                    return null;
            }
        }

    }

}