using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTarget : Target
{
    protected override void OnHit()
    {
        scoreSystem.ScoreBadTarget();
    }
}
