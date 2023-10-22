using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBrick : Brick
{
    public override void Start()
    {
        health = 2;
        base.Start();
    }
}
