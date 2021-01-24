using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackUpState : EnemyBaseState
{
    private Vector3 _targetPos;
    public float _speed = 9;

    public override void EnterState(EnemyFSM enemy)
    {
       _targetPos = enemy.transform.position - enemy.transform.up * 2.0f;
    }

    public override void Update(EnemyFSM enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, _targetPos, _speed * Time.deltaTime);

        if (Vector2.Distance(enemy.transform.position, _targetPos) < Mathf.Epsilon) 
        {
            enemy.TransitionToState(enemy._EnemyFollowState);
        }
    }

    public override void EnemyPushedBack(EnemyFSM enemy)
    {
    }
}
