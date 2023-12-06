using System.Collections.Generic;
using UnityEngine;

public interface IBrick : IBrickHit, IBrickSpawn, ISetBrickSprite
{
    int Health { get; set; }
    int HitPoints { get; set; }
    int DestroyedPoints { get; set; }
    bool Unbreakable { get; set; }
    List<Sprite> States { get; set; }
}
