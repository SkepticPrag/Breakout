using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, IBrick
{
    public int Health { get; set; }
    public int HitPoints { get; set; }
    public int DestroyedPoints { get; set; }
    public bool Unbreakable { get; set; }

    SpriteRenderer _spriteRenderer;
    SpriteRenderer spriteRenderer => _spriteRenderer = _spriteRenderer ? _spriteRenderer : GetComponentInParent<SpriteRenderer>();

    BoxCollider2D boxCollider2D;

    public List<Sprite> States { get; set; }

    public void GetBrickReady(int healthState)
    {
        gameObject.AddComponent<BoxCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = null;
        spriteRenderer.sprite = States[healthState - 1];
        SetBoxColliderOnSprite(spriteRenderer.sprite);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            if (!IsUnbreakable())
                Hit();
        }
    }

    public void Hit()
    {
        --Health;

        if (Health <= 0)
        {
            GameManager.Instance.AddScore(DestroyedPoints);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.AddScore(HitPoints);
            spriteRenderer.sprite = States[Health - 1];
        }
    }

    private bool IsUnbreakable()
    {
        if (Unbreakable)
            return true;

        return false;
    }

    public void SetBoxColliderOnSprite(Sprite state)
    {
        spriteRenderer.sprite = state;
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        boxCollider2D.size = spriteSize;
    }
}
