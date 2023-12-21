using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour 
{
    private bool _isEmployed;
    private float _scaleMod = 0.5f;

    public bool IsEmployed => _isEmployed;

    public void SetStatus()
    {
        _isEmployed = true;
    }

    public void SetScale()
    {
        transform.localScale *= _scaleMod;
    }
}
