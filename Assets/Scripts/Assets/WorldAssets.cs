using System;
using UnityEngine;

namespace Sample2D {

    public class WorldAssets : MonoBehaviour {

        [SerializeField] MapEntity mapPrefab;
        [SerializeField] RoleEntity rolePrefab;

        public MapEntity GetMapPrefab() {
            return mapPrefab;
        }

        public RoleEntity GetRolePrefab() {
            return rolePrefab;
        }

    }

}