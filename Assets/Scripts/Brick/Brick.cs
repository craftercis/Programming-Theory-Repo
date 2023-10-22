using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Color32 basicBrickColor = new Color32(215, 255, 233, 255);
    private Color32 hardBrickColor = new Color32(253, 193, 70, 255);
    private Color32 UltraBrickColor = new Color32(255, 83, 83, 255);

    public int health;

    // Start is called before the first frame update
    public virtual void Start()
    {
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveHealth()
    {
        health -= GameManager.instance.dammageValue;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            SetColor();
        }
    }

    public void SetColor()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (health)
        {
            case 1:
                block.SetColor("_Color", basicBrickColor);
                break;
            case 2:
                block.SetColor("_Color", hardBrickColor);
                break;
            case 3:
                block.SetColor("_Color", UltraBrickColor);
                break;
        }

        renderer.SetPropertyBlock(block);
    }
}
