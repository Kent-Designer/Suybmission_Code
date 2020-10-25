using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertIP : MonoBehaviour
{
    public GameObject netman;
    InputField IP;
    string address;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IPAdress()
    {
        address = IP.text;
        Debug.Log(address);
        netman.GetComponent<NetworkManager>().networkAddress = address;
    }
}
