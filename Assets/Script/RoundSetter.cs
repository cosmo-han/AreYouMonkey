using System.Collections.Generic;
using UnityEngine;

public class RoundSetter : MonoBehaviour
{
    [SerializeField]
    private CorrectSo mouseCorrectSO;

    [SerializeField]
    private CorrectSo keyBoardCorrectSO;

    public List<Vector3> GetMouseCorrect() => linePosition;

    List<Vector3> linePosition = new List<Vector3>();
    public List<Vector3> GetMouseQuestion()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = RandIndex(mouseCorrectSO.point.Length);
            linePosition.Add(mouseCorrectSO.point[rand]);
        }

        return linePosition;
    }

    List<string> key = new List<string>();

    public List<string> GetKeyBoardCorrect() => key;

    public List<string> GetKeyBoardQuestion()
    {
        List<string> list = new List<string>();
        for (int i = 0; i < 3; i++)
        {
            int rand = RandIndex(keyBoardCorrectSO.key.Length);
            key.Add(keyBoardCorrectSO.key[rand]);
        }

        return list;
    }

    private int RandIndex(int max)
    {
        int index = Random.Range(0, max);
        return index;
    }
}
