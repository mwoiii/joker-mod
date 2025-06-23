using UnityEngine;

namespace JokerMod.Joker.Components.UI {
    public class StatBarController : MonoBehaviour {
        private float maxStat;

        [SerializeField]
        private float width;

        [SerializeField]
        private float height;

        [SerializeField]
        private RectTransform statBar;

        public void SetMaxStat(float maxStat) {
            this.maxStat = maxStat;
        }

        public void SetStat(float stat) {
            if (maxStat * width != 0f) {
                float newWidth = stat / maxStat * width;
                statBar.sizeDelta = new Vector2(newWidth, height);
            }
        }
    }
}
