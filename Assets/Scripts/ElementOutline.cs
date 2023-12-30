using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementOutline : MonoBehaviour
{
    private bool isLogPlaced = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void AddLog(Transform parent)
    {
        if (!isLogPlaced)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);

                if (child.CompareTag("Log") && !isLogPlaced && !child.gameObject.GetComponent<LogManager>().IsBuilt())
                {
                    isLogPlaced = true;
                    child.gameObject.GetComponent<LogManager>().ChangeToLogMaterial();
                    break;
                }
                AddLog(child);
            }
        }
    }

    public void AddLog()
    {
        AddLog(transform);
        isLogPlaced = false;
    }
}
