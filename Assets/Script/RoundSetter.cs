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
    public List<GameObject> GetMouseQuestion()
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            int rand = RandIndex(mouseCorrectSO.corrects.Length);
            list.Add(mouseCorrectSO.corrects[rand]);

            var line = mouseCorrectSO.corrects[rand].GetComponent<LineRenderer>();
            for (int j = 0; j < line.positionCount; j++)
            {
                var pos = new Vector3(line.GetPosition(j).x, line.GetPosition(j).y, line.GetPosition(j).z);
                linePosition.Add(pos);
            }
        }
        return list;
    }

    List<string> key = new List<string>();

    public List<string> GetKeyBoardCorrect() => key;

    public List<GameObject> GetKeyBoardQuestion()
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            int rand = RandIndex(keyBoardCorrectSO.corrects.Length);
            list.Add(keyBoardCorrectSO.corrects[rand]);
            key.Add(keyBoardCorrectSO.corrects[rand].GetComponent<TextMesh>().text);
        }

        return list;
    }

    private int RandIndex(int max)
    {
        int index = Random.Range(0, max);
        return index;
    }
}
