using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraBrick : Brick
{
    public override void Start()
    {
        health = 3;
        base.Start();
    }
}
