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
        private readonly int ROUND = 10;

        [SerializeField]
        private Score score;
        [SerializeField]
        private Timer timer;
        IEnumerator enumerator;

        void Start()
        {
            lobbyPanel.SetActive(true);
            enumerator = MyCoroutine();
            startButton.onClick.AddListener(GameStart);
        }

        private void GameStart()
        {
            lobbyPanel.SetActive(false);           
            StartCoroutine(enumerator);
            timer.IsPlay = true;
            questionCount = 0;
            score.StartScore(ROUND);
        }

        private void SetNextQuestion()
        {
            MouseChecker.Instance.RedDot = 0;
            MouseChecker.Instance.CanAddDot();
            QuestionSetter.Instance.SetMouseQuestion();
            QuestionSetter.Instance.SetKeyBoardQuestion();
            questionCount++;
        }

        private void CheckScore()
        {
            MouseChecker.Instance.CountDot();
            if (MouseChecker.Instance.IsCorrect)
            {
                score.SetScore(-score.RoundScore);
            }
            if (KeyBoardChecker.Instance.IsCorrect)
            {
                score.SetScore(-score.RoundScore);
            }
        }

        private void EndRound()
        {
            CheckScore();
            if(MouseChecker.Instance.CurrentLine != null)
            {
                Destroy(MouseChecker.Instance.CurrentLine?.gameObject);
            }
            QuestionSetter.Instance.ClearDotObject();
            QuestionSetter.Instance.ClearKeyObject();
            QuestionSetter.Instance.ClearPointObject();
            MouseChecker.Instance.StopAddDot();

            if (questionCount == ROUND - 1)
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            lobbyPanel.SetActive(true);
            score.PrintScore();
            timer.IsPlay = false;
            StopCoroutine(enumerator);
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
