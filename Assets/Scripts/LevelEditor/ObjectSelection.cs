using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject objectPlacer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (panel.activeSelf == true) 
            {
                panel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (panel.activeSelf == false)
            {
                panel.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    public void SetObject(string objectName)
    {
        objectPlacer.GetComponent<ObjectPlacer>().chosenObjectName = objectName;
        objectPlacer.GetComponent<ObjectPlacer>().ChosenObjects();
    }
}
