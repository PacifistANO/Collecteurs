using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawner : MonoBehaviour
{
    [SerializeField] private Resource _recourcePrefab;
    [SerializeField] private Vector3 _highLeftPointOfZone;
    [SerializeField] private Vector3 _bottomRightPointOfZone;
    [SerializeField] private float _timeBeforeSpawn;

    private Vector3 _spawnPoint;
    private float _randX;
    private float _randZ;
    private float _timer;

    private void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0)
        {
            Spawn();
            _timer = _timeBeforeSpawn;
        }
    }

    private void Spawn()
    {
        _randX = UnityEngine.Random.Range(_highLeftPointOfZone.x, _bottomRightPointOfZone.x);
        _randZ = UnityEngine.Random.Range(_highLeftPointOfZone.z, _bottomRightPointOfZone.z);
        _spawnPoint = new Vector3(_randX, transform.position.y, _randZ);
        Instantiate(_recourcePrefab, _spawnPoint, Quaternion.identity);
    }
}
