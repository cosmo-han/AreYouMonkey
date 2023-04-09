using UnityEngine;
using TMPro;

namespace MonkeyGame
{
    public class Score : MonoBehaviour
    {
        private readonly int START_SCORE = 100;
        private readonly int QUESTION = 2;
        private int currentScore;
        private int roundScore;
        public int RoundScore { get => roundScore; }

        private TextMeshProUGUI scoreText;

        private void Start()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            scoreText.text = "";
        }

        public void StartScore(int round)
        {
            currentScore = START_SCORE;
            roundScore = START_SCORE / round / QUESTION;
        }

        public void SetScore(int sum) => currentScore += sum;

        public void PrintScore() => scoreText.text = $"ฟ๘ผþทย : {currentScore}%";
    }
}
