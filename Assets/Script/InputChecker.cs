using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame
{
    public class InputChecker : MonoBehaviour
    {
        private bool isCorrect = false;
        public bool IsCorrect { get => isCorrect; set => isCorrect = value; }
    }
}