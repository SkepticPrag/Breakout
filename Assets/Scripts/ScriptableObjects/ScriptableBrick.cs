using UnityEngine;

[CreateAssetMenu(fileName = "New Brick")]
public class ScriptableBrick : ScriptableObject
{
    public string brickName;

    public ScriptableStates states;
    
    public GameObject brickPrefab;

    public int health;
    public int hitPoints;
    public int destroyedPoints;

    public bool unbreakable;

    
}
