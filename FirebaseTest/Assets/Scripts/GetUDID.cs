using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUDID : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = SystemInfo.deviceUniqueIdentifier;
    }
}
