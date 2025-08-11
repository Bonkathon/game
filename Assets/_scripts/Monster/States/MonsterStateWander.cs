using UnityEngine;

public class MonsterStateWander : IMonsterState
{
    private readonly MovementMotor _motor;
    private readonly Transform _transform;
    private readonly MonsterStateMachine _stateMachine;

    private float _wanderRadius = 10f;
    private Vector3 _targetPosition;
    private bool _hasDestination;


    public MonsterStateWander(
        MovementMotor motor,
        Transform transform,
        MonsterStateMachine stateMachine)
    {
        _motor = motor;
        _transform = transform;
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        ChooseNewDestination();
        // Debug.Log("Entrou no estado Wander");
    }

    public void Tick()
    {
        if (!_hasDestination) return;

        if (_motor.IsArrived())
        {
            // Debug.Log("Arrived destination in Wander");
            _stateMachine.ChangeState(MonsterStateType.Idle);
        }
    }

    public void OnExit()
    {
        _motor.Stop();
        _hasDestination = false;
        // Debug.Log("Saiu do estado Wander");
    }

    private void ChooseNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _wanderRadius;
        randomDirection += _transform.position;
        randomDirection.y = _transform.position.y;
        _targetPosition = randomDirection;
        _motor.MoveTo(_targetPosition);
        _hasDestination = true;
    }
}
