using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetMover))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Transform _pointResource;
    
    private Base _homeBase;
    private Vector3 _stayPosition;
    private Quaternion _stayRotation;
    private bool _isBusy;
    private Resource _portableResource;
    private TargetMover _targetMover;

    public bool IsBusy => _isBusy;
    public TargetMover TargetMover => _targetMover; 

    private void Start()
    {
        _isBusy = false;
        _targetMover = GetComponent<TargetMover>();
    }

    private void Update()
    {
        if (_targetMover.IsArrived)
        {
            if (_targetMover.Target.TryGetComponent<Resource>(out Resource res))
                TakeResource(res);
            else if (_portableResource)
                PutResource();
        }
    }

    public void SetStartPosition(Vector3 position, Quaternion rotation)
    {
        _stayPosition = position;
        _stayRotation = rotation;
    } 
    
    public void SetPosition()
    {
        transform.position = _stayPosition;
        transform.rotation = _stayRotation;
    }

    public void SetUnitStatus(bool status)
    {
        _isBusy = status;
    }

    public void TakeResource(Resource res)
    {
        res.transform.SetParent(transform,true);
        res.transform.position = _pointResource.position;
        res.ChangeScale();
        _portableResource = res;
        _targetMover.SetTarget(_homeBase.transform.GetChild(0).gameObject);
        _targetMover.OnMoveToTarget();
    }

    public void PutResource()
    {
        _homeBase.AddResource(_portableResource);
        Destroy(_portableResource.gameObject);
        _isBusy = false;
        _targetMover.ResetStatus();
        SetPosition();
    }

    public void SetHomeBase(Base homeBase)
    {
        _homeBase = homeBase;
    }
}
