using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MouseCorrectScriptableObject", order = 1)]
public class MouseCorrectSo : ScriptableObject
{
    public GameObject pointPrefab;
    public Shape[] Shapes;
}

[System.Serializable]
public class Shape
{
   public Vector3[] pointPositons;
}