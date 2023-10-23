using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class UltraBrick : Brick
{
    // POLYMORPHISM
    public override void Start()
    {
        health = 3;
        base.Start();
    }
}
