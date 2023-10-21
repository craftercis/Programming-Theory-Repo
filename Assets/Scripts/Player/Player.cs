using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float maxMovementX = 7.632f;
    private float maxMovementY = -1f;
    private float bottomBorder = -3f;
    private float maxBounceAngle = 75.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        MoveHorizontal();
    }

    public void MoveHorizontal()
    {
        float input = Input.GetAxis("Horizontal");
        
        Vector3 pos = transform.position;
        pos.x += input * speed * Time.deltaTime;

        if (pos.x > maxMovementX)
        {
            pos.x = maxMovementX;
        }
        else if (pos.x < -maxMovementX)
        {
            pos.x = -maxMovementX;
        }

        transform.position = pos;
    }

    protected void MoveVertical()
    {
        float input = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.y += input * speed * Time.deltaTime;

        if (pos.y > maxMovementY)
        {
            pos.y = maxMovementY;
        }
        else if (pos.y < bottomBorder)
        {
            pos.y = bottomBorder;
        }

        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            // Get the contact point between the paddle and the ball
            Vector3 contactPoint = collision.GetContact(0).point;

            // Get the center position of the paddle
            Vector3 paddleCenter = transform.position;

            // Calculate the horizontal offset between the contact point and the paddle center
            float offset = contactPoint.x - paddleCenter.x;

            // Calculate the half-width of the paddle
            float width = GetComponent<BoxCollider>().bounds.size.x / 2;

            // Calculate the direction in which the ball is moving right now, in relation to the front of the paddle.
            float currentAngle = Vector3.SignedAngle(Vector3.up, ball.GetComponent<Rigidbody>().velocity, Vector3.forward);

            // Calculate the bounce angle based on the offset and the maximum bounce angle
            // (It decides how much the ball should bounce off based on where it hit the paddle. If it hits closer to the edges, it will bounce more)
            float bounceAngle = (offset / width) * -maxBounceAngle;

            // Clamp the new angle to stay within the maximum bounce angle limits
            // (This makes sure the bounce angle doesn't get too extreme. It limits the bounce within a certain range).
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            // Create a rotation based on the new angle around the up axis
            // (Here, it creates a new direction for the ball to move based on the bounce angle. Think of it as telling the ball which way to go after the bounce).
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            // Apply the rotation to the ball's velocity vector to change its direction
            // (Finally, it changes the ball's movement direction using the calculated bounce angle and its speed, so it bounces off the paddle correctly).
            ball.GetComponent<Rigidbody>().velocity = rotation * Vector3.up * ball.GetComponent<Rigidbody>().velocity.magnitude;
        }
    }
}
