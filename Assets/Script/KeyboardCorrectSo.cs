using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/KeyboardCorrectScriptableObject", order = 1)]
public class KeyboardCorrectSo : ScriptableObject
{
    public GameObject keyPrefab;
    public string[] keyString;
}