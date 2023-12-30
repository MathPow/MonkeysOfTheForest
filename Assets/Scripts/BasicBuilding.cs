using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBuilding : MonoBehaviour
{
    /*
    PROBLÈMES :
    - Outline contact with Wall

    */
    [SerializeField] private GameObject buildingOutline;
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject hudManager;
    [SerializeField] private GameObject[] playerLogs;

    [SerializeField] private bool buldingModeOn = true;
    [SerializeField] private float rotationSpeed = 12f;
    [SerializeField] private float snapDistance = 1.5f;

    private float rotateMultiplicator = 0f;
    private float rotateTimerMax = 5f;
    RaycastHit hit;

    void Start()
    {
        foreach (GameObject log in playerLogs)
        {
            log.SetActive(false);
        }
    }

    void Update()
    {
        if (buldingModeOn)
        {
            buildingOutline.SetActive(true);
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 8))
            {
                buildingOutline.transform.position = hit.point;
                if (Input.GetKeyDown(KeyCode.F))
                    Instantiate(buildingPrefab, hit.point, buildingOutline.transform.rotation);
            }
            else
            {
                buildingOutline.SetActive(false);
            }
            GameObject wall = FindClosestWall();
            /*if (wall != null)
            {
                float distance = Vector3.Distance(wall.transform.position, buildingOutline.transform.position);
                if (distance < snapDistance)
                {
                    Vector3 snapPosition = wall.transform.position + wall.transform.forward * snapDistance;
                    buildingOutline.transform.position = snapPosition;
                }
            }*/
        }
        else
            buildingOutline.SetActive(false);

        if (Input.GetKeyDown(KeyCode.R))
            buldingModeOn = !buldingModeOn;
        if (Input.GetKey(KeyCode.C))
        {
            if(rotateMultiplicator <= rotateTimerMax)
                rotateMultiplicator += Time.deltaTime * 2;
            buildingOutline.transform.Rotate(Vector3.up * rotationSpeed * rotateMultiplicator * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (rotateMultiplicator <= rotateTimerMax)
                rotateMultiplicator += Time.deltaTime * 2;
            buildingOutline.transform.Rotate(Vector3.down * rotationSpeed * rotateMultiplicator * Time.deltaTime);
        }
       if(!Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.X))
        {
            rotateMultiplicator = 1;
        }
    }

    private GameObject FindClosestWall()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        float closestDistance = Mathf.Infinity;
        GameObject closestWall = null;

        foreach (GameObject wall in walls)
        {
            float distance = Vector3.Distance(transform.position, wall.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestWall = wall;
            }
        }
        return closestWall;
    }

    void OnTriggerEnter(Collider collider)
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Tree") && Input.GetKeyDown(KeyCode.E))
        {
            collider.GetComponent<TreeManager>().CutDownTree();
        }
        if (collider.CompareTag("Log") && Input.GetKeyDown(KeyCode.E))
        {
            GivePlayerLog(collider);
        }
        if (collider.CompareTag("House") && Input.GetKeyDown(KeyCode.E))
        {
            RemovePlayerLog(collider);
        }
    }

    private int GetNbOfActive()
    {
        int playerLogsActive = 0;
        foreach (GameObject log in playerLogs)
        {
            if (log.activeSelf)
                playerLogsActive++;
        }
        return playerLogsActive;
    }

    private void GivePlayerLog(Collider collider)
    {
        if (GetNbOfActive() < 2 && collider.GetComponent<Rigidbody>())
        {
            collider.GetComponent<LogManager>().PickUpLog();
            if (playerLogs[0].activeSelf)
                playerLogs[1].SetActive(true);
            else
                playerLogs[0].SetActive(true);
        }
    }

    private void RemovePlayerLog(Collider collider)
    {
        if (GetNbOfActive() > 0)
        {
            collider.GetComponent<ElementOutline>().AddLog();
            if (!playerLogs[1].activeSelf)
                playerLogs[0].SetActive(false);
            else
                playerLogs[1].SetActive(false);
        }
    }
}
