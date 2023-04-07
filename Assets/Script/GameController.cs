using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject lobbyPanel;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private Button startButton;


    void Start()
    {
        lobbyPanel.SetActive(true);
        gamePanel.SetActive(false);
        startButton.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        lobbyPanel.SetActive(false);
        gamePanel.SetActive(true);
        // RoundSetter.GetMouseQuestion(), GetKeyBoardQuestion() ���� ����
        // InputChecker.keyCorrect, mouseCorrect = RoundSetter.GetMouseCorrect, GetKeyBoardCorrect ��������
    }
}
