using UnityEngine;
using TMPro;

namespace MonkeyGame
{
    public class Timer : MonoBehaviour
    {
        private float time;
        private readonly float MAX_TIME = 5;
        private TextMeshProUGUI timeText;

        private bool isPlay;
        public bool IsPlay { get => isPlay; set => isPlay = value; }

        private void Start()
        {
            time = MAX_TIME;
            timeText = GetComponent<TextMeshProUGUI>();
        }

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
