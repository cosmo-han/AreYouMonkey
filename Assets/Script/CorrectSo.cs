using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CorrectScriptableObject", order = 1)]
public class CorrectSo : ScriptableObject
{
    public GameObject[] corrects;
    public string[] keyCorrects;
}

