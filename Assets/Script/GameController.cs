using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace MonkeyGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject lobbyPanel;
        [SerializeField]
        private Button startButton;
        int questionCount;
        public readonly int ROUND = 10;
        public readonly int ROUND_SCORE = 5;

        [SerializeField]
        private Score score;
        [SerializeField]
        private Timer timer;

        void Start()
        {
            lobbyPanel.SetActive(true);        
            startButton.onClick.AddListener(GameStart);
        }

        private void GameStart()
        {
            lobbyPanel.SetActive(false);
            StartCoroutine(MyCoroutine());
            timer.IsPlay = true;
        }

        private void SetNextQuestion()
        {
            MouseChecker.Instance.RedDot = 0;
            MouseChecker.Instance.CanAddDot();
            QuestionSetter.Instance.SetMouseQuestion();
            QuestionSetter.Instance.SetKeyBoardQuestion();
            questionCount++;
            Debug.Log(score.GetScore);
            if (questionCount == ROUND)
            {
                lobbyPanel.SetActive(true);
                score.PrintScore();
                timer.IsPlay = false;
            }
        }

        private void CheckScore()
        {
            if (MouseChecker.Instance.IsCorrect)
            {
                score.SetScore(-ROUND_SCORE);
            }
            if (KeyBoardChecker.Instance.IsCorrect)
            {
                score.SetScore(-ROUND_SCORE);
            }
        }

        private void EndRound()
        {
            CheckScore();
            Destroy(MouseChecker.Instance.CurrentLine?.gameObject);
            QuestionSetter.Instance.ClearDotObject();
            QuestionSetter.Instance.ClearKeyObject();
            QuestionSetter.Instance.ClearPointObject();
            MouseChecker.Instance.StopAddDot();
        }

        private IEnumerator MyCoroutine()
        {
            while (true)
            {
                SetNextQuestion();
                yield return new WaitForSeconds(timer.ResetTime());
                EndRound();
            }
        }
    }
}
