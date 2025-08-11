using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovementMotor : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
            Debug.LogError("NavMeshAgent não encontrado no objeto.");
    }

    public void MoveTo(Vector3 destination)
    {
        if (_agent == null) return;
        _agent.isStopped = false;
        _agent.SetDestination(destination);
    }

    public void Stop()
    {
        if (_agent == null) return;
        _agent.isStopped = true;
    }

    public bool IsArrived()
    {
        if (_agent == null) return true;

        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
            return true;

        return false;
    }
}
