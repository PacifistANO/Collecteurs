using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour 
{
    private float _scaleMod = 0.5f;

    public void ChangeScale()
    {
        transform.localScale *= _scaleMod;
    }
}
