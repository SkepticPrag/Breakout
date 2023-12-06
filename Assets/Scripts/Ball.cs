using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{

    Rigidbody2D _rigidBody2D;
    public Rigidbody2D rigidBody2D => _rigidBody2D = _rigidBody2D ? _rigidBody2D : GetComponent<Rigidbody2D>();

    public float speed;

    [SerializeField]
    float velocityMagnitude;

    private void Start()
    {
        ResetBall();
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rigidBody2D.AddForce(force.normalized * speed * 50);

    }
    private void Update()
    {
        velocityMagnitude = rigidBody2D.velocity.magnitude;
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }
}
