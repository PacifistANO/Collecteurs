using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour 
{
    private bool _isEmployed;

    public bool IsEmployed => _isEmployed;

    public void SetStatus()
    {
        _isEmployed = true;
    }

    public void SetScale()
    {
        transform.localScale *= 0.5f;
    }
}
