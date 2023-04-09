using UnityEngine;
using TMPro;

namespace MonkeyGame
{
    public class Score : MonoBehaviour
    {
        private int score;
        public int GetScore { get => score; private set => score = value; }
        private TextMeshProUGUI scoreText;

        private void Start()
        {
            score = 100;
            scoreText = GetComponent<TextMeshProUGUI>();
            scoreText.text = "";
        }

        public void SetScore(int sum) => GetScore += sum;

        public void PrintScore() => scoreText.text = $"ฟ๘ผþทย : {GetScore}%";
    }
}
