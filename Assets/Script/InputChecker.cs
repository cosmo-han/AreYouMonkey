using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    private string[] keyCorrect;//RoundSetter
    private Vector3[] mouseCorrect;//RoundSetter

    private List<string> keyInput;

    GameObject linePrefab;
    private List<Vector3> mouseInput;

    private void Update()
    {
        //라인 그리기
        //mouseInput에 position 저장
        //keyboard input
    }

    private bool CheckCorrect()
    {
        bool correct = false;
        int correctCount = 0;
        foreach (var item in keyCorrect)
        {
            foreach (var my in keyInput)
            {
                if(item == my)
                {
                    correctCount++;
                }

            }
        }

        if(keyCorrect.Length/correctCount > 0.7)
        {
            correct = true;
        }

        return correct;
    }
}
