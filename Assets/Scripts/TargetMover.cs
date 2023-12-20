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

    public void OnMoveToTarget()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, _target.transform.position) > 1f)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(_target.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("SprintJump");

            yield return null;
        }

        gameObject.GetComponent<Animator>().ResetTrigger("SprintJump");

        if (_target.TryGetComponent<Resource>(out Resource res))
            GetComponent<Unit>().TakeResource(res);
        else
            GetComponent<Unit>().PutResource();
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
