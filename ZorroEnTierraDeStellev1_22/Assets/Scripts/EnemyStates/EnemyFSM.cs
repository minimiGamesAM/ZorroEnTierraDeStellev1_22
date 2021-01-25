using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public readonly EnemyIdleState _EnemyIdleState = new EnemyIdleState();
    public readonly EnemyAttackState _EnemyAttackState = new EnemyAttackState();
    public readonly EnemyPatrolState _EnemyPatrolState = new EnemyPatrolState();
    public readonly EnemyFollowState _EnemyFollowState = new EnemyFollowState();
    public readonly EnemyBackUpState _EnemyBackUpdState = new EnemyBackUpState();

    private EnemyBaseState _currentState;
    private Vector2 _patrolPoint;

    PlayerController _player;

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

    void EnemyPushedBack(Collider2D collider)
    {
        if (collider.gameObject.name == this.name)
        {
            _currentState.EnemyPushedBack(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _patrolPoint = transform.position; 
        TransitionToState(_EnemyPatrolState);

        //_player = GameObject.Find("Player");
        _player = FindObjectOfType<PlayerController>();

        _player.EnemyPushBack += EnemyPushedBack;
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.Update(this);
    }
}
