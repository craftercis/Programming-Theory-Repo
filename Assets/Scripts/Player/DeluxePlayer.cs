using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeluxePlayer : Player
{
    public override void Update()
    {
        base.Update();
        MoveVertical();
    }
}
