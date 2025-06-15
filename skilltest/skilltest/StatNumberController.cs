using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SkillTest {
    public class StatNumberController : MonoBehaviour {
        private TMP_Text statText;
        public bool hasStarted;

        private void Start() {
            statText = GetComponent<TMP_Text>();
            hasStarted = true;
            Log.Info("legit only just got it lol");
        }

        public void SetStat(float stat) {
            statText.text = $"{(int)stat}";
        }
    }
}
