using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame
{
    public class Timer : MonoBehaviour
    {
        public static float time;

        void Update()
        {
            time += Time.deltaTime;
            if(time < 3)
            {
                if (MouseChecker.Instance.isCorrect())
                {
                    Score.Instance.SetScore(-5);
                }
                if (KeyBoardChecker.Instance.isCorrect())
                {
                    Score.Instance.SetScore(-5);
                }
            }
        }
    }
}
