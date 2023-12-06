using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New States")]
public class ScriptableStates : ScriptableObject
{
    public List<Sprite> States;
    public Sprite UnbreakableState;
}
