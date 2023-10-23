using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class HardBrick : Brick
{
    // POLYMORPHISM
    public override void Start()
    {
        health = 2;
        base.Start();
    }
}
