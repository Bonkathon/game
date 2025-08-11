using UnityEngine;

public class MonsterStateFlee : IMonsterState
{
    private MovementMotor _motor;
    private Transform _monsterTransform;
    private Transform _threat;
    private float _fleeRadius = 10f;

    public MonsterStateFlee(MovementMotor motor, Transform monsterTransform, Transform threat)
    {
        _motor = motor;
        _monsterTransform = monsterTransform;
        _threat = threat;
    }

    public void OnEnter()
    {
        Debug.Log("Entrou no estado Flee");
        FleeFromThreat();
    }

    public void Tick()
    {
        if (_motor.IsArrived())
        {
            FleeFromThreat();
        }
    }

    public void OnExit()
    {
        _motor.Stop();
        Debug.Log("Saiu do estado Flee");
    }

    private void FleeFromThreat()
    {
        if (_threat == null) return;

        Vector3 direction = (_monsterTransform.position - _threat.position).normalized;
        Vector3 fleePosition = _monsterTransform.position + direction * _fleeRadius;
        _motor.MoveTo(fleePosition);
    }
}
