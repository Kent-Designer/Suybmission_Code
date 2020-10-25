using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdowns : MonoBehaviour
{
    public GameObject timeDropdown;
    public GameObject mapDropdown;

    //private static readonly string timerPref = "Timer";
    //private static readonly string mapPref = "Map";
    public float timer;
    public string map;
    public void TimeDropdown()
    {
        List<Dropdown.OptionData> menuOptions = timeDropdown.GetComponent<Dropdown>().options;
        timer = float.Parse(menuOptions[timeDropdown.GetComponent<Dropdown>().value].text);
        List<Dropdown.OptionData> mapOptions = mapDropdown.GetComponent<Dropdown>().options;
        map=mapOptions[mapDropdown.GetComponent<Dropdown>().value].text;
    }
}
