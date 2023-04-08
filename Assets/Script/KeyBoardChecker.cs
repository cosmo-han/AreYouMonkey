using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MonkeyGame
{
    public class KeyBoardChecker : MonoBehaviour
    {
        public static KeyBoardChecker Instance;

        private void Awake()
        {
            Instance = this;
        }

        List<string> inputKeys = new();

        void Update()
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey) && inputKeys.Count < 4)
                {
                    inputKeys.Add($"{vKey}");
                }
            }
        }


        public bool isCorrect(bool correct = false) => correct;
    }
}
