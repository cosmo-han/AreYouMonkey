using UnityEngine;
using TMPro;

namespace MonkeyGame
{
    public class Score : MonoBehaviour
    {
        public static Score Instance;

        private void Awake()
        {
            Instance = this;
        }

        public int score = 100;
        //public int SetScore { get; set; }
        private TextMeshProUGUI scoreText;

        private void Start()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            scoreText.text = "";
        }

        public void SetScore(int sum)
        {
            score += sum;
            scoreText.text = $"ฟ๘ผþทย : {score}%";
        }
    }
}
