using UnityEngine;

[RequireComponent(typeof(MovementMotor))]
public class MonsterStateController : MonoBehaviour
{
    public MovementMotor motor;
    public MonsterStateMachine stateMachine;

    void Awake()
    {
        if (motor == null)
            motor = GetComponent<MovementMotor>();

        stateMachine = new MonsterStateMachine();
        
        // Opcional: conectar callbacks
        stateMachine.OnStateChanged += HandleStateChanged;

        // Registrar estados
        stateMachine.RegisterState(MonsterStateType.Idle, new MonsterStateIdle(motor, stateMachine));
        stateMachine.RegisterState(MonsterStateType.Wander, new MonsterStateWander(motor, transform, stateMachine));
        // registrar outros estados conforme necessário

        // Definir estado inicial como Idle
        stateMachine.ChangeState(MonsterStateType.Idle);
    }

    void Update()
    {
        if (stateMachine != null)
            stateMachine.UpdateState();
    }

    private void HandleStateChanged(IMonsterState newState)
    {
        Debug.Log($"Novo estado: {newState.GetType().Name}");
    }
}
