using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Color32 basicBrickColor = new Color32(215, 255, 233, 255);
    private Color32 hardBrickColor = new Color32(253, 193, 70, 255);
    private Color32 UltraBrickColor = new Color32(255, 83, 83, 255);

    private int pointReward = 1;

    public int health;

    // Start is called before the first frame update
    public virtual void Start()
    {
        SetColor();
    }

    public void RemoveHealth()
    {
        health -= GameManager.instance.dammageValue;
        GameManager.instance.AddPoint(pointReward);

        if (health <= 0)
        {
            GameManager.instance.bricks.Remove(this);
            Destroy(gameObject);
        }
        else
        {
            SetColor();
        }
    }

    // ABSTRACTION
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
