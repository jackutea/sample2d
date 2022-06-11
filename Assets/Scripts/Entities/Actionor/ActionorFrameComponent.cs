using System;
using UnityEngine;

namespace Sample2D {

    public interface IActionorFrameComponent {
        string Name { get; }
    }

    // 一帧动作
    public class ActionorFrameComponent : MonoBehaviour, IActionorFrameComponent {

        string IActionorFrameComponent.Name => gameObject.name;

        // 攻击盒
        ActionorFrameAttackBoxComponent atkBox;

        // 受击盒
        ActionorFrameDefenseBoxComponent defBox;

        // 防御盒
        ActionorFrameBodyBoxComponent bodyBox;

        public void Ctor() {

            atkBox = GetComponentInChildren<ActionorFrameAttackBoxComponent>(true);
            defBox = GetComponentInChildren<ActionorFrameDefenseBoxComponent>(true);
            bodyBox = GetComponentInChildren<ActionorFrameBodyBoxComponent>(true);

            atkBox.Inject(this);
            defBox.Inject(this);
            bodyBox.Inject(this);

        }

    }

}