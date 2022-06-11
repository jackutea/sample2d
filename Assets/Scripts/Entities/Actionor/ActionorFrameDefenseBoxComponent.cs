using System;
using UnityEngine;

namespace Sample2D {

    public class ActionorFrameDefenseBoxComponent : MonoBehaviour {

        IActionorFrameComponent actionorFrameComponent;

        public void Inject(IActionorFrameComponent actionorFrameComponent) {
            this.actionorFrameComponent = actionorFrameComponent;
        }

    }

}