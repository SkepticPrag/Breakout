using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;
    SpriteRenderer spriteRenderer => _spriteRenderer = _spriteRenderer ? _spriteRenderer : GetComponent<SpriteRenderer>();

    public Sprite[] states;

    public int hitPoints;
    public int deathPoints;
    public int health;
    public bool unbreakable;

    private void Start()
    {
        if (!unbreakable)
        {
            spriteRenderer.sprite = states[health - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            Hit();
        }
    }

    private void Hit()
    {
        if (unbreakable)
            return;

        --health;

        if (health <= 0)
        {
            GameManager.Instance.AddScore(deathPoints);
            gameObject.SetActive(false);

        }
        else
        {
            GameManager.Instance.AddScore(hitPoints);
            spriteRenderer.sprite = states[health - 1];
        }
    }
}
