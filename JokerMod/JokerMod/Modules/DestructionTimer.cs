using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace JokerMod.Modules {
    public class DestructionTimer : MonoBehaviour {
        private float timeLeft = 60f;

        public void SetTimeLeft(float time) {
            this.timeLeft = time;
        }

        private void FixedUpdate() {
            timeLeft -= Time.fixedDeltaTime;
            if (timeLeft <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
