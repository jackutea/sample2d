using System;
using UnityEngine;

namespace Sample2D {

    public class ActionorFrameAttackBoxComponent : MonoBehaviour {

        IActionorFrameComponent actionorFrameComponent;

        public void Inject(IActionorFrameComponent actionorFrameComponent) {
            this.actionorFrameComponent = actionorFrameComponent;
        }

        void OnTriggerEnter2D(Collider2D other) {
            GameObject go = other.gameObject;
            if (go.CompareTag(TagCollection.MONSTER)) {
                // 怪物
                Debug.Log($"{actionorFrameComponent.Name} TRIGGER: {other.gameObject.name}");
            }
        }

    }

}