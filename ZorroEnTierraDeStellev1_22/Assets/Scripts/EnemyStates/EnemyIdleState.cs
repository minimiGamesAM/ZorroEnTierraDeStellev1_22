using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyFSM enemy)
    {
       
    }

    public override void Update(EnemyFSM enemy)
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
            enemy.TransitionToState(enemy._EnemyFollowState);
       }
    }
}
