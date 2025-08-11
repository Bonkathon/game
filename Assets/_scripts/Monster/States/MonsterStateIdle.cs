using UnityEngine;

public class MonsterStateIdle : IMonsterState
{
    private readonly MovementMotor _motor;
    private readonly MonsterStateMachine _stateMachine;

    private float _timer;
    private readonly float _minIdleTime = 2f;  // tempo mínimo parado
    private readonly float _maxIdleTime = 5f;  // tempo máximo parado

    public MonsterStateIdle(
        MovementMotor motor,
        MonsterStateMachine stateMachine)
    {
        _motor = motor;
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        _motor.Stop();
        _timer = Random.Range(_minIdleTime, _maxIdleTime);
        // Debug.Log($"Idle por {_timer} segundos");
    }

    public void Tick()
    {
        // Comportamento parado
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            _stateMachine.ChangeState(MonsterStateType.Wander);
        }
    }

    public void OnExit()
    {
        // UnityEngine.Debug.Log("Saiu do estado Idle");
    }
}
