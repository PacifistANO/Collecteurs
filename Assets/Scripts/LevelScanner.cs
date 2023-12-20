using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

[RequireComponent(typeof(Base))]
public class LevelScanner : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TMP_Text _resourcesInfo;

    private int _scanZoneSize = 40;
    private List<Collider> _resources;
    private Base _base;

    public List<Collider> Resources => _resources;

    private void Start()
    {
        _base = GetComponent<Base>();
    }

    private void FixedUpdate()
    {
        ScanZone();

        if(_resources.Count > 0)
        {
            _base.CollectResource();
        }
    }

    private void ScanZone()
    {
        _resources = Physics.OverlapSphere(transform.position, _scanZoneSize, _layerMask).ToList<Collider>();
        ScanningInfo();
    }
    private void ScanningInfo()
    {
        _resourcesInfo.text = $"Ресурсы для сбора - {_resources.Count}";
    }
}
