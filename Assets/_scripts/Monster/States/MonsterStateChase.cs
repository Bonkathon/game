using UnityEngine;

public class MonsterStateChase : IMonsterState
{
    private MovementMotor _motor;
    private Transform _target;

    public MonsterStateChase(MovementMotor motor, Transform target)
    {
        _motor = motor;
        _target = target;
    }

    public void OnEnter()
    {
        Debug.Log("Entrou no estado Chase");
    }

    public void Tick()
    {
        if (_target == null) return;

        _motor.MoveTo(_target.position);
    }

    public void OnExit()
    {
        _motor.Stop();
        Debug.Log("Saiu do estado Chase");
    }
}
