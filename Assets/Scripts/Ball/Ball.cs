using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBall()
    {
        ballRb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        ballRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
