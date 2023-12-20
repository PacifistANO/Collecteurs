using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(LevelScanner))]
public class Base : MonoBehaviour
{
    [SerializeField] private TMP_Text _unitsInfo;
    [SerializeField] private TMP_Text _resourcesInfo;

    private int _baseId = 0;
    private List<Unit> _units = new List<Unit>();
    private List<Resource> _resources = new List<Resource>();
    private LevelScanner _scanner;

    private void Start()
    {
        UnitsInfo();
        ResourceInfo();
    }

    private void UnitsInfo()
    {
        _unitsInfo.text = $"Количество юнитов - {_units.Count}";
    }

    private void ResourceInfo()
    {
        _resourcesInfo.text = $"Количество доступных ресурсов - {_resources.Count}";
    }

    public void AddUnit(Unit unit)
    {
        _units.Add(unit);
        UnitsInfo();
    }

    public void CollectResource()
    {
        _scanner = GetComponent<LevelScanner>();
        int resourceId = Random.Range(0, _scanner.Resources.Count);

        if (!_scanner.Resources[resourceId].GetComponent<Resource>().IsEmployed)
        {
            foreach (Unit unit in _units)
            {
                if (!unit.IsBusy)
                {
                    unit.GetComponent<TargetMover>().SetTarget(_scanner.Resources[resourceId].gameObject);
                    unit.GetComponent<TargetMover>().OnMoveToTarget();
                    unit.SetUnitStatus(true);
                    _scanner.Resources[resourceId].GetComponent<Resource>().SetStatus();
                    break;
                }
            }
        }
    }

    public void AddResource(Resource resource)
    {
        _resources.Add(resource);
        ResourceInfo();
    }
}
