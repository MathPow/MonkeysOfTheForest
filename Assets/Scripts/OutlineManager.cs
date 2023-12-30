using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    [SerializeField] private Material wallMaterial;
    [SerializeField] private Material wallErrorMaterial;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Wall"))
        {
            ChangeObjectMaterial(wallErrorMaterial);
        } 
        else
        {
            ChangeObjectMaterial(wallMaterial);
        }
    }

    private void ChangeObjectMaterial(Material newMaterial)
    {
        Transform transformParent = transform.GetChild(0);
        for (int i = 0; i < transformParent.childCount; i++)
        {
            Transform child = transformParent.GetChild(i);
            child.gameObject.GetComponent<Renderer>().material = newMaterial;
        }
    }
}
