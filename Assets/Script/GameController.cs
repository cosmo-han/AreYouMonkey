using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject lobbyPanel;
    [SerializeField]
    private Button startButton;


    void Start()
    {
        lobbyPanel.SetActive(true);
        startButton.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        lobbyPanel.SetActive(false);
        // RoundSetter.GetMouseQuestion(), GetKeyBoardQuestion() 문제 세팅
        // InputChecker.keyCorrect, mouseCorrect = RoundSetter.GetMouseCorrect, GetKeyBoardCorrect 정답전달
    }
}
