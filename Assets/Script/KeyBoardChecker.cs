using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace MonkeyGame
{
    public class KeyBoardChecker : InputChecker
    {
        public static KeyBoardChecker Instance;

        private void Awake()
        {
            Instance = this;
        }

        private readonly int SIZE = 3;
        private Queue<string> inputKeys = new();
        public Queue<string> GetInputKeys { get => inputKeys; }

        void Update()
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey))
                {
                    if((int)vKey >= 97 && (int)vKey <= 122)
                    {
                        KeyEnqueue(inputKeys, $"{vKey}");
                        IsCorrect = QuestionSetter.Instance.GetKeyBoardCorrect().SequenceEqual(inputKeys);
                    }
                }
            }
        }

        public void KeyEnqueue(Queue<string> queue, string item)
        {
            queue.Enqueue(item);
            if (queue.Count > SIZE)
            {
                queue.Dequeue();
            }
        }
    }
}
