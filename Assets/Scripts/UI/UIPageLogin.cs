using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sample2D.UIRenderer {

    public class UIPageLogin : MonoBehaviour {

        Button startGameButton;

        public event Action OnStartGameHandle;

        void Awake() {

            startGameButton = transform.GetChild(0).GetComponent<Button>();

            // 断言
            Debug.Assert(startGameButton != null);

            startGameButton.onClick.AddListener(() => {
                OnStartGameHandle.Invoke();
            });

        }

    }

}