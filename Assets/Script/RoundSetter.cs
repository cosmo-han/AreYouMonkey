using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonkeyGame
{
    public class RoundSetter : MonoBehaviour
    {
        public static RoundSetter Instance;

        private void Awake()
        {
            Instance = this;
        }

        public Transform mouseCorrectParents;
        [SerializeField]
        private MouseCorrectSo mouseCorrectSO;

        public Transform keyboardCorrectParents;
        [SerializeField]
        private KeyboardCorrectSo keyboardCorrectSO;

        private List<GameObject> points = new();


        public List<GameObject> GetMouseCorrect() => points;

        public List<GameObject> SetMouseQuestion()//·£´ý ¼öÁ¤ -> °ãÄ¡¸é ´Ù½Ã rand
        {
            for (int i = 0; i < RandIndex(2, mouseCorrectSO.pointPositon.Length); i++)
            {
                GameObject point = Instantiate(mouseCorrectSO.pointPrefab, mouseCorrectParents);
                int rand = RandIndex(0, mouseCorrectSO.pointPositon.Length);
                point.transform.localPosition = mouseCorrectSO.pointPositon[rand];
                points.Add(point);
            }
            return points;
        }

        List<GameObject> keys = new();

        public List<GameObject> GetKeyBoardCorrect() => keys;

        public List<GameObject> SetKeyBoardQuestion()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject Key = Instantiate(keyboardCorrectSO.keyPrefab, keyboardCorrectParents);
                Key.transform.localPosition = new Vector3(i * 100 - 100, 0, 0);
                int rand = RandIndex(0, keyboardCorrectSO.keyString.Length);
                Key.GetComponent<TextMeshProUGUI>().text = keyboardCorrectSO.keyString[rand];
                keys.Add(Key);
            }

            return keys;
        }

        private int RandIndex(int min, int max)
        {
            int index = Random.Range(min, max);
            return index;
        }
    }
}

