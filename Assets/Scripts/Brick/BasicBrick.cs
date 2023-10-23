using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BasicBrick : Brick
{
    // POLYMORPHISM
    public override void Start()
    {
        health = 1;
        base.Start();
    }
}
