using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonkeyGame
{
    public class QuestionSetter : MonoBehaviour
    {
        public static QuestionSetter Instance;

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField]
        private Transform mouseCorrectParents;
        [SerializeField]
        private MouseCorrectSo mouseCorrectSO;

        [SerializeField]
        private Transform keyboardCorrectParents;
        [SerializeField]
        private KeyboardCorrectSo keyboardCorrectSO;

        private List<GameObject> points;


        public List<GameObject> GetMouseCorrect() => points;

        public void SetMouseQuestion()//·£´ý ¼öÁ¤ -> °ãÄ¡¸é ´Ù½Ã rand
        {
            points = new();
            for (int i = 0; i < RandIndex(2, mouseCorrectSO.pointPositon.Length); i++)
            {
                GameObject point = Instantiate(mouseCorrectSO.pointPrefab, mouseCorrectParents);
                int rand = RandIndex(0, mouseCorrectSO.pointPositon.Length);
                point.transform.localPosition = mouseCorrectSO.pointPositon[rand];
                points.Add(point);
            }
        }

        private Queue<string> keys = new();
        private List<GameObject> keyObjects;

        public Queue<string> GetKeyBoardCorrect() => keys;

        public void SetKeyBoardQuestion()
        {
            keyObjects = new();
            for (int i = 0; i < 3; i++)
            {
                GameObject Key = Instantiate(keyboardCorrectSO.keyPrefab, keyboardCorrectParents);
                Key.transform.localPosition = new Vector3(i * 100 - 100, 0, 0);
                int rand = RandIndex(0, keyboardCorrectSO.keyString.Length);
                keyObjects.Add(Key);
                Key.GetComponent<TextMeshProUGUI>().text = keyboardCorrectSO.keyString[rand];
                KeyBoardChecker.Instance.KeyEnqueue(keys, keyboardCorrectSO.keyString[rand]);            
            }
        }

        private int RandIndex(int min, int max)
        {
            int index = Random.Range(min, max);
            return index;
        }

        public void ClearKeyObject() => ClearChecker(keyObjects);
        public void ClearPointObject() => ClearChecker(points);
        public void ClearDotObject()
        {
            ClearChecker(MouseChecker.Instance.Dots);
            MouseChecker.Instance.NewDot();
        }


        private void ClearChecker(List<GameObject> gameObjects)
        {
            foreach (var obj in gameObjects)
            {
                Destroy(obj);
                Debug.Log(obj.name);
            }
            gameObjects.Clear();
        }
    }
}

