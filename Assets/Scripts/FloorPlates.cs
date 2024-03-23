using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlates : MonoBehaviour
{

    private bool _activated= false;

    public Action PlateActivation;

    [SerializeField] private Material _activationMaterial;
    [SerializeField] private Material _deactivatedMaterial;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Reset();
    }

    public void Reset()
    {
        _activated = false;
        SetMaterial();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_activated== false) {

            _activated = true;
            SetMaterial();
            PlateActivation?.Invoke();
        }
    }

    private void SetMaterial()
    {
        if(_activated) {
            _meshRenderer.material = _activationMaterial;

        }
        else
        {
            _meshRenderer.material = _deactivatedMaterial;
        }
    }
}
