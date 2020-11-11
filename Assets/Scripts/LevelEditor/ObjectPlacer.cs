using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPlacer : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] GameObject chosenObject;
    [SerializeField] GameObject[] placeableObjects;
    [SerializeField] GameObject[] SpawnedObjects;
    public string chosenObjectName;
    [SerializeField] float rotation = 0f;
    public DataManager dataManager;

    private void Update()
    {
        if (panel.activeSelf == false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                AddObject();
            }
            if (Input.GetMouseButtonUp(1))
            {
                RemoveObject();
            }
        }
        else if (panel.activeSelf == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (rotation < 360f)
            {
                rotation += 45f;
            }
            else if (rotation == 360f) 
            {
                rotation = 45f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            SaveObjects();
        }
    }

    public void ChosenObjects() 
    {
        for (int i = 0; i < placeableObjects.Length; i++)
        {
            if (placeableObjects[i].name == chosenObjectName)
            {
                chosenObject = placeableObjects[i];
            }
            else 
            {
            
            }
        }
    }

    void AddObject() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) 
        {
            Vector3 pos = hit.point;

            GameObject newB = Instantiate(chosenObject, pos, Quaternion.Euler(new Vector3(0, rotation, 0)));
        }
    }

    void SaveObjects() 
    {
        SpawnedObjects = GameObject.FindGameObjectsWithTag("Spawned");
        foreach (GameObject Object in SpawnedObjects) 
        {
            var objectName = Object.name.Replace("(Clone)", string.Empty);
            dataManager.data.placedObjects.Add(objectName);
            dataManager.data.placedObjectLocation.Add(Object.transform.position);
            dataManager.data.placedObjectRotation.Add(Object.transform.eulerAngles);
        }
        dataManager.Save();
        SceneManager.LoadScene(0);
    }

    void RemoveObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag != "indestructible")
            {
                Destroy(hit.collider.gameObject);
            }
            else 
            {
            
            }
        }
    }
}
