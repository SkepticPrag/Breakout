using UnityEngine;

[CreateAssetMenu(fileName = "New Brick")]
public class ScriptableBrick : ScriptableObject
{
    public string brickName;

    public GameObject brickPrefab;

    public int health;
    public int hitPoints;
    public int destructionPoints;

    public bool unbreakable;
}
