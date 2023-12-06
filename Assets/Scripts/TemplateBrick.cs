using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TemplateBrick : MonoBehaviour
{
    [SerializeField]
    ScriptableBrick brickToSpawn;
    GameObject brickPrefab;

    private void Awake()
    {
        brickPrefab = Instantiate(brickToSpawn.brickPrefab, transform.position, Quaternion.identity, transform);
        IBrick brick = brickPrefab.GetComponent<IBrick>();

        brick.Health = brickToSpawn.health;
        brick.HitPoints = brickToSpawn.hitPoints;
        brick.Unbreakable = brickToSpawn.unbreakable;
        brick.DestroyedPoints = brickToSpawn.destroyedPoints;

        brick.States = new List<Sprite>();

        brick.States.Clear();
        brick.States = brickToSpawn.states.States;

        brick.GetBrickReady(brick.Health);

        gameObject.name = brickToSpawn.brickName;
    }
}
