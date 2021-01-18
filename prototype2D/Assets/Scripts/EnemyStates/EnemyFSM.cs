using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public readonly EnemyIdleState _EnemyIdleState = new EnemyIdleState();
    public readonly EnemyAttackState _EnemyAttackState = new EnemyAttackState();
    public readonly EnemyPatrolState _EnemyPatrolState = new EnemyPatrolState();
    public readonly EnemyFollowState _EnemyFollowState = new EnemyFollowState();

    private EnemyBaseState _currentState;
    private Vector2 _patrolPoint;

    public Vector2 PatrolPoint
    {
        get { return _patrolPoint; }
    }

    public void TransitionToState(EnemyBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }

    public void rotate(Vector3 targetToLookAt)
    {
        Quaternion desiredQuaternion = Quaternion.LookRotation(transform.forward, targetToLookAt - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredQuaternion, 1000 * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        _patrolPoint = transform.position; 
        TransitionToState(_EnemyPatrolState);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.Update(this);
    }
}
