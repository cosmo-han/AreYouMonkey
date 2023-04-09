using UnityEngine;
using TMPro;

namespace MonkeyGame
{
    public class Timer : MonoBehaviour
    {
        private float time;
        public readonly float MAX_TIME = 10;
        private TextMeshProUGUI timeText;

        private bool isPlay;
        public bool IsPlay { get => isPlay; set => isPlay = value; }

        private void Start()
        {
            time = MAX_TIME;
            timeText = GetComponent<TextMeshProUGUI>();
        }
        public float GetTime { get => time; private set => time = value; }

        void Update()
        {
            if (IsPlay)
            {
                time -= Time.deltaTime;
                timeText.text = $"{((int)time)}";
            }
        }

        public float ResetTime() => time = MAX_TIME;
    }
}
