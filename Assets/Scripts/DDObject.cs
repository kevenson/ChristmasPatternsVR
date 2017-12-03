﻿using UnityEngine;

public class DDObject : MonoBehaviour, DragDropHandler
{
    public Material gazedAtMaterial, inactiveMaterial;
    private bool isHeld;
    private GameObject reticle;

    void Start()
    {
        isHeld = false;
        reticle = GameObject.Find("GvrReticlePointer");
    }

    void Update()
    {
        if (isHeld)
        {
            Ray ray = new Ray(reticle.transform.position, reticle.transform.forward);
            transform.position = ray.GetPoint(5);
        }
    }

    public void HandleGazeTriggerStart()
    {
        isHeld = true;
    }
    public void HandleGazeTriggerEnd()
    {
        isHeld = false;
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }
}