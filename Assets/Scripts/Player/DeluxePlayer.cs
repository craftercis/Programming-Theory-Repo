using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class DeluxePlayer : Player
{
    // POLYMORPHISM
    public override void Update()
    {
        base.Update();
        MoveVertical();
    }
}
