using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBrick : Brick
{
    public override void Start()
    {
        health = 1;
        base.Start();
    }
}
