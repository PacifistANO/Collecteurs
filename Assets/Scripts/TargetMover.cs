using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Unit))]
public class TargetMover : MonoBehaviour
{
    private GameObject _target;
    private string _sprint = "SprintJump";
    private Unit _unit;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _unit = GetComponent<Unit>();
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void OnMoveToTarget()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, _target.transform.position) > 1f)
        {
            _navMeshAgent.SetDestination(_target.transform.position);
            _animator.SetTrigger(_sprint);

            yield return null;
        }

        _animator.ResetTrigger(_sprint);

        if (_target.TryGetComponent<Resource>(out Resource res))
            _unit.TakeResource(res);
        else
            _unit.PutResource();
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}

