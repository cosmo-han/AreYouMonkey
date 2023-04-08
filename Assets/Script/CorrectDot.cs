using UnityEngine;
using UnityEngine.UI;

namespace MonkeyGame
{
    public class CorrectDot : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("trigger");
            other.GetComponent<Image>().color = Color.red;
        }
    }
}
