using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public DataManager dataManager;
    [SerializeField] GameObject[] placeableObjects;

    void Start()
    {
        dataManager.Load();
        LoadObjects();
    }

    void LoadObjects() 
    {
        for (int i = 0; i < dataManager.data.placedObjects.Count; i++)
        {
            for (int j = 0; j < placeableObjects.Length; j++)
            {
                if (placeableObjects[j].name == dataManager.data.placedObjects[i])
                {
                    Instantiate(placeableObjects[j], dataManager.data.placedObjectLocation[i], Quaternion.Euler(dataManager.data.placedObjectRotation[i]));
                }
                else
                {

                }
            }
        }
    }
}
