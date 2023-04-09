using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

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
        [SerializeField] 
        private TextMeshProUGUI myInput;


        void Update()
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey))
                {
                    if ((int)vKey >= 97 && (int)vKey <= 122)
                    {
                        KeyEnqueue(inputKeys, $"{vKey}");
                        myInput.text += $"{vKey}";
                        IsCorrect = QuestionSetter.Instance.GetKeyBoardCorrect().SequenceEqual(inputKeys);
                        if (IsCorrect)
                        {
                            myInput.color = Color.green;
                        }
                        else
                        {
                            myInput.color = Color.white;
                        }
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

        public void ResetInputText()
        {
            myInput.color = Color.white;
            myInput.text = "¿Œ«≤ : ";
            IsCorrect = false;
        }
    }
}
