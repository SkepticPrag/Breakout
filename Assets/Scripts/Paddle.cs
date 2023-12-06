using UnityEngine;


[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
public class Paddle : MonoBehaviour
{
    Rigidbody2D _rigidBody2D;
    Rigidbody2D rigidBody2D => _rigidBody2D = _rigidBody2D ? _rigidBody2D : GetComponent<Rigidbody2D>();

    float speed = 30f;
    Vector2 direction;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
            rigidBody2D.AddForce(direction * speed);
    }
}
