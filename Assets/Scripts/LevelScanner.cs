using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class LevelScanner : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TMP_Text _resourcesInfo;

    private int _scanZoneSize = 40;
    private List<Collider> _resources;

    public List<Collider> Resources => _resources;

    private void FixedUpdate()
    {
        ScanZone();

        if(_resources.Count > 0)
        {
            GetComponent<Base>().CollectResource();
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
