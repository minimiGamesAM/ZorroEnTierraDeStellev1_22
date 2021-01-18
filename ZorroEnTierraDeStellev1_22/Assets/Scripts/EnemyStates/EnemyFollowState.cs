using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyBaseState
{
    private Transform _playerPos;
    public float _speed = 3;
   
    public override void EnterState(EnemyFSM enemy)
    {
        _playerPos = GameObject.Find("Player").transform;
    }

    public override void Update(EnemyFSM enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, _playerPos.position, _speed * Time.deltaTime);
        enemy.rotate(_playerPos.position);

        if (Vector2.Distance(enemy.transform.position, _playerPos.position) > 6.0f)
        {
            enemy.TransitionToState(enemy._EnemyPatrolState);
        }
    }

}
