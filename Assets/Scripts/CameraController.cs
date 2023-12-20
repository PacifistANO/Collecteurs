using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _zoomSpeed;

    private int _rotateDirection;
    private float _rotateBoost;
    private float _maxHeight = 10;
    private float _minHeight = -10;

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        _rotateDirection = 0;

        if (Input.GetKey(KeyCode.Q))
        {
            _rotateDirection = -1;
            _rotateBoost += Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.E))
        {
            _rotateDirection = 1;
            _rotateBoost += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Q) ||  Input.GetKeyUp(KeyCode.E))
        {
            _rotateBoost = 1;
        }

        transform.Rotate(Vector3.up * _rotateSpeed * _rotateDirection * _rotateBoost * Time.deltaTime, Space.World);
        transform.Translate(new Vector3(horizontalDirection, 0, verticalDirection) * _moveSpeed * Time.deltaTime, Space.Self);
        transform.Translate(new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0) * _zoomSpeed * Time.deltaTime, Space.Self);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _minHeight, _maxHeight), transform.position.z);
    }
}
