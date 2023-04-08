using UnityEngine;
using UnityEngine.UI;

namespace MonkeyGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject lobbyPanel;
        [SerializeField]
        private Button startButton;
        int questionCount;

        void Start()
        {
            lobbyPanel.SetActive(true);        
            startButton.onClick.AddListener(GameStart);
        }

        private void GameStart()
        {
            lobbyPanel.SetActive(false);
            NextQuestion();
            // RoundSetter.GetMouseQuestion(), GetKeyBoardQuestion() 문제 세팅
            // InputChecker.keyCorrect, mouseCorrect = RoundSetter.GetMouseCorrect, GetKeyBoardCorrect 정답전달
        }

        private void NextQuestion()
        {
            RoundSetter.Instance.SetMouseQuestion();
            RoundSetter.Instance.SetKeyBoardQuestion();
            Timer.time = 0;
            questionCount++;
            if (questionCount > 9)
            {
                lobbyPanel.SetActive(true);               
            }
        }
    }
}
