using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private Vector2 _randomPoint;
    private float _speed = 1.0f;
    private Transform _playerPos;

    private void calculateRandomPoint(EnemyFSM enemy)
    {
        _randomPoint.x = Random.Range(-2, 2);
        _randomPoint.y = Random.Range(-2, 2);

        _playerPos = GameObject.Find("Player").transform;
    }

    public override void EnterState(EnemyFSM enemy)
    {
        calculateRandomPoint(enemy);
    }

    public override void Update(EnemyFSM enemy)
    {
        enemy.rotate(enemy.PatrolPoint + _randomPoint);

        if(Vector2.Distance(enemy.PatrolPoint + _randomPoint, enemy.transform.position) > 0.2f)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.PatrolPoint + _randomPoint, _speed * Time.deltaTime);
        }
        else
        {
            calculateRandomPoint(enemy);
        }

        if(Vector2.Distance(enemy.transform.position, _playerPos.position) < 1.0f)
        {
            enemy.TransitionToState(enemy._EnemyFollowState);
        }
    }
}
