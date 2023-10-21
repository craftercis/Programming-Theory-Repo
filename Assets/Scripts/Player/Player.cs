using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float maxMovementX = 7.632f;
    private float maxMovementY = -1f;
    private float bottomBorder = -3f;

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
}
