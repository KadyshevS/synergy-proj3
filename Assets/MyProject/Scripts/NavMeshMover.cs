using UnityEngine;
using UnityEngine.AI;

public class NavMeshMover : MonoBehaviour
{
    private NavMeshAgent  _agent; 
    private Animator      _animator;
    public float RemainingDistance => _agent.remainingDistance;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void MoveTo(Vector3 position, float velocity = 1f)
    {
        _agent.isStopped = false;
        _agent.SetDestination(position);
        _agent.speed = 3.5f * velocity;
        _animator.SetFloat("Vertical Speed", _agent.velocity.magnitude * velocity);
    }
    public void Stop()
    {
        _agent.isStopped = true;
        _animator.SetFloat("Vertical Speed", 0.0f);
    }
}
