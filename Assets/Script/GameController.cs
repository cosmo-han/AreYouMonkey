using UnityEngine;
using UnityEngine.UI;
using MonkeyGame;

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
        RoundSetter.Instance.SetMouseQuestion();
        RoundSetter.Instance.SetKeyBoardQuestion();
        // RoundSetter.GetMouseQuestion(), GetKeyBoardQuestion() ���� ����
        // InputChecker.keyCorrect, mouseCorrect = RoundSetter.GetMouseCorrect, GetKeyBoardCorrect ��������
    }
}
