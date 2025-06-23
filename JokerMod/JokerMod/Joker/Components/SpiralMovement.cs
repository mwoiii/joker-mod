using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.Components {
    public class SpiralMovement : MonoBehaviour {
        public float spiralRadius = 3f;
        public float spiralSpeed = 2f;
        public float angle = 0f;

        private Vector3 prevTransform;
        private Vector3 forwardDir;

        private void Start() {
            forwardDir = transform.forward;
        }

        private void Update() {
            // subtract to return to what would be position without previous transformation
            transform.position -= prevTransform;

            // calculate new position in the circle relative to the forward direction
            angle += spiralSpeed * Time.deltaTime;
            float rightMult = spiralRadius * Mathf.Cos(angle);
            float upMult = spiralRadius * Mathf.Sin(angle);
            Vector3 right = Vector3.Cross(Vector3.up, forwardDir).normalized;
            Vector3 up = Vector3.Cross(forwardDir, right).normalized;
            Vector3 newTransform = right * rightMult + up * upMult;

            // apply position and store transformation
            transform.position += newTransform; 
            prevTransform = newTransform;
        }
    }
}
