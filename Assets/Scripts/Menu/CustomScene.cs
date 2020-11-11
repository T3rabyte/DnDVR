using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class CustomScene : MonoBehaviour
{
    [SerializeField] TMP_InputField saveNameInputField;
    public void CreateSave()
    {
        if (string.IsNullOrEmpty(saveNameInputField.text))
        {
            return;
        }
        else 
        {
            PhotonNetwork.LoadLevel(2);
        }
    }

}
