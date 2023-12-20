using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotater : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}
