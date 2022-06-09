using System;
using UnityEngine;
using Cinemachine;

namespace Sample2D {

    public class CameraEntity : MonoBehaviour {

        Transform stand;
        CinemachineVirtualCamera cm;

        CinemachineConfiner2D confiner2D;

        void Awake() {

            stand = transform.GetChild(0);
            cm = stand.GetChild(0).GetComponent<CinemachineVirtualCamera>();

            confiner2D = cm.GetComponent<CinemachineConfiner2D>();

            Debug.Assert(confiner2D != null);

        }

        public void SetFollow(Transform target) {
            cm.Follow = target;
        }

        public void SetConfiner(PolygonCollider2D confiner) {
            confiner2D.m_BoundingShape2D = confiner;
        }

    }

}