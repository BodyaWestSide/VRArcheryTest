using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodTarget : Target
{
    protected override void OnHit()
    {
        scoreSystem.ScoreGoodTarget();
    }
}
