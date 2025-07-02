using TMPro;
using UnityEngine;

namespace JokerMod.Joker.Components.UI {
    public class StatNumberController : MonoBehaviour {
        private TMP_Text statText;

        public bool hasStarted;

        public string suffix = "";

        private void Awake() {
            statText = GetComponent<TMP_Text>();
            hasStarted = true;
        }

        public void SetStat(float stat) {
            statText.text = $"{(int)stat}{suffix}";
        }
    }
}
