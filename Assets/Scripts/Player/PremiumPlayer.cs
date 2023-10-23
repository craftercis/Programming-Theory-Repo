using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PremiumPlayer : Player
{
    // POLYMORPHISM
    public override void Update()
    {
        base.Update();
        MoveVertical();
    }
}
