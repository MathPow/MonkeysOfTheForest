using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CutDownTree()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.name == "Leafs")
                child.gameObject.SetActive(false);
            if (child.CompareTag("Log"))
                child.gameObject.AddComponent<Rigidbody>();
        }
    }
}
