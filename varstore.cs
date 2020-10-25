using JetBrains.Annotations;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class varstore : MonoBehaviour
{
    public float time = 60;
    public int players = 0;
    public GameObject timer;
    public GameObject netman;
    public GameObject evil;

    // Start is called before the first frame update
    public void setTime()
    {
         List < Dropdown.OptionData > menuOptions = timer.GetComponent<Dropdown>().options;
         time = float.Parse(menuOptions[timer.GetComponent<Dropdown>().value].text);
    }
    public void evilMan()
    {
        netman.GetComponent<NetworkManager>().playerPrefab = evil; 
    }
}
