using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Base))]
public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private int _startCountOfUnits;
    [SerializeField] private Unit _unitPrefab;

    private Base _base;

    private void Start()
    {
        _base = GetComponent<Base>();
        StartCoroutine(SpawnUnit(_startCountOfUnits));
    }

    private IEnumerator SpawnUnit(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Vector3 spawnPoint = new Vector3(transform.GetChild(0).position.x + Random.Range(-1f,1f), 
                transform.GetChild(0).position.y, 
                transform.GetChild(0).position.z + Random.Range(-1f, 1f));
            Unit newUnit = Instantiate(_unitPrefab, spawnPoint, Quaternion.identity);
            newUnit.transform.rotation = Quaternion.Euler(0, 135, 0);
            newUnit.SetStartPosition(transform.position,transform.rotation);
            newUnit.SetHomeBase(_base);
            _base.AddUnit(newUnit);
            yield return null;
        }
    }
}
