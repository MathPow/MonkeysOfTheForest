using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    [SerializeField] private Material logMaterial;
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private Material errorMaterial;
    [SerializeField] private LogMaterial actualMaterial;
    enum LogMaterial
    {
        Wood,
        Outline,
        Error,
    }

    void Start()
    {
        if (actualMaterial == LogMaterial.Wood)
            ChangeToLogMaterial();
        else if (actualMaterial == LogMaterial.Outline)
            ChangeToOutlineMaterial();
        else if (actualMaterial == LogMaterial.Error)
            ChangeToErrorMaterial();
    }

    void Update()
    {
        
    }

    public void ChangeToLogMaterial()
    {
        actualMaterial = LogMaterial.Wood;
        GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Renderer>().material = logMaterial;
    }

    public void ChangeToOutlineMaterial()
    {
        actualMaterial = LogMaterial.Outline;
        GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().material = outlineMaterial;
    }

    public void ChangeToErrorMaterial()
    {
        actualMaterial = LogMaterial.Error;
        GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().material = errorMaterial;
    }

    public bool IsBuilt()
    {
        return actualMaterial == LogMaterial.Wood;
    }

    public void PickUpLog()
    {
        Destroy(gameObject);
    }
}
