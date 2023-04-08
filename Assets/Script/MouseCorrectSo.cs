using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MouseCorrectScriptableObject", order = 1)]
public class MouseCorrectSo : ScriptableObject
{
    public GameObject pointPrefab;
    public Vector3[] pointPositon;
}