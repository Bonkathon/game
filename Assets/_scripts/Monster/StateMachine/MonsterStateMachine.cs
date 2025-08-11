using UnityEngine;
using System;
using System.Collections.Generic;

public class MonsterStateMachine
{
    private IMonsterState _currentState;
    private readonly Dictionary<MonsterStateType, IMonsterState> _states = new();

    // Callback para alertar quando um novo estado for adicionado
    public Action<IMonsterState> OnStateChanged;

    public void RegisterState(MonsterStateType stateKey, IMonsterState state)
    {
        if (!_states.ContainsKey(stateKey))
            _states.Add(stateKey, state);
    }

    public void ChangeState(MonsterStateType newStateKey)
    {
        _currentState?.OnExit();

        if (_states.TryGetValue(newStateKey, out var state))
        {
            _currentState = state;
            _currentState.OnEnter();
            OnStateChanged?.Invoke(_currentState);
        }
        else
        {
            Debug.LogWarning($"Estado {newStateKey} não registrado.");
        }
    }

    public void UpdateState()
    {
        _currentState?.Tick();
    }
}
