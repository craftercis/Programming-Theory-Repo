using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiumPlayer : Player
{
    public override void Update()
    {
        base.Update();
        MoveVertical();
    }
}
