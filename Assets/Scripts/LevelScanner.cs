using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

[RequireComponent(typeof(Base))]
public class LevelScanner : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private int _scanZoneSize = 40;
    private Queue<Collider> _resources = new Queue<Collider>();
    private int _timeBeforeScan = 2;

    public Queue<Collider> Resources => _resources;

    private void Start()
    {
        StartCoroutine(Scanning());
    }

    private IEnumerator Scanning()
    {
        WaitForSeconds waitingTime = new WaitForSeconds(_timeBeforeScan);

        while (true)
        {
            Collider[] resources = Physics.OverlapSphere(transform.position, _scanZoneSize, _layerMask);

            foreach (Collider res in resources)
            {
                _resources.Enqueue(res);
            }

            yield return waitingTime;
        }
    }

    public void RemoveResourceFromQueue()
    {
        _resources.Dequeue().gameObject.layer = 0;
    }
}
