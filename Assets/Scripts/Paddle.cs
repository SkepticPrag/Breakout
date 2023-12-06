using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(BoxCollider2D))]
public class Paddle : MonoBehaviour
{
    Rigidbody2D _rigidBody2D;
    public Rigidbody2D rigidBody2D => _rigidBody2D = _rigidBody2D ? _rigidBody2D : GetComponent<Rigidbody2D>();

    float speed = 10f;
    float maxBounceAngle = 75f;

    Vector3 direction;

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        direction = new Vector2(direction.x, 0f);

        transform.position += direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidBody2D.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidBody2D.velocity = rotation * Vector2.up * ball.speed;
        }
    }

    internal void ResetPaddle()
    {
        transform.position = new Vector2(0f, transform.position.y);
        rigidBody2D.velocity = Vector2.zero;
    }
}
