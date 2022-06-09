using System;
using UnityEngine;

namespace Sample2D {

    public class MapEntity : MonoBehaviour {

        SpriteRenderer background;

        SpriteRenderer ground;

        void Awake() {

            background = transform.GetChild(0).GetComponent<SpriteRenderer>();
            ground = transform.GetChild(1).GetComponent<SpriteRenderer>();

            Debug.Assert(background != null);
            Debug.Assert(ground != null);

        }

    }

}