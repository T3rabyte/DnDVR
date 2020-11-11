using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ObjectData
{
    public List<String> placedObjects = new List<String>();
    public List<Vector3> placedObjectLocation = new List<Vector3>();
    public List<Vector3> placedObjectRotation = new List<Vector3>();
}
