using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    public void ResetBall()
    {
        ballRb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        ballRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null)
        {
            brick.RemoveHealth();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        var velocity = ballRb.velocity;

        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.01f;

        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        //max velocity
        if (velocity.magnitude > 4.0f)
        {
            velocity = velocity.normalized * 4.0f;
        }

        ballRb.velocity = velocity;
    }
}
