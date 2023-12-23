using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(UnitAnimator))]
public class TargetMover : MonoBehaviour
{
    private GameObject _target;
    private UnitAnimator _unitAnimator;
    private NavMeshAgent _navMeshAgent;
    private float _minDistanceToTarget = 1f;
    private bool _isArrived;

    public bool IsArrived => _isArrived;
    public GameObject Target => _target;

    private void Start()
    {
        _unitAnimator = GetComponent<UnitAnimator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, _target.transform.position) > _minDistanceToTarget)
        {
            _navMeshAgent.SetDestination(_target.transform.position);
            _unitAnimator.OnSprint();

            yield return null;
        }

        _isArrived = true;
        _unitAnimator.OffSprint();
    }

    public void OnMoveToTarget()
    {
        StartCoroutine(MoveToTarget());
    }

    public void SetTarget(GameObject target)
    {
        _isArrived = false;
        _target = target;
    }

    public void ResetStatus()
    {
        _isArrived = false;
    }
}

