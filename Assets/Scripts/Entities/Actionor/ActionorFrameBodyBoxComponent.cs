using System;
using UnityEngine;

namespace Sample2D {

    public class ActionorFrameBodyBoxComponent : MonoBehaviour {

        IActionorFrameComponent actionorFrameComponent;

        public void Inject(IActionorFrameComponent actionorFrameComponent) {
            this.actionorFrameComponent = actionorFrameComponent;
        }

    }

}