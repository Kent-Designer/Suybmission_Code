using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;
using System.Linq;



public class timer : MonoBehaviour
{
    public float time;
    public float maxtime;

    GameObject varybill;
    GameObject netman;
    public GameObject playerboi;
    GameObject[] bois;//= new GameObject[] { };

    // Start is called before the first frame update
    void Start()
    {
        netman = GameObject.Find("NetManger");
        //netman.GetComponent<NetworkManager>().playerPrefab = playerboi;
        varybill = GameObject.Find("VarStore");

        time = varybill.GetComponent<varstore>().time;
        maxtime = time;
        Debug.Log(varybill);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.GetComponent<Text>().text = (Mathf.Floor(time) + "'s");  
        time -= Time.deltaTime;
        if (time < maxtime-.5f)
        {
            
            netman.GetComponent<NetworkManager>().playerPrefab = playerboi;
        }
        if(time < maxtime - 5f)
        {
            var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "P1(Clone)");
            bois = objects.ToArray() ;
            if (bois.Length > 0)
            {
                bool lose = true;
                for (int i = 0; i < bois.Length; i++)
                {
                    if (bois[i].GetComponent<controlerPlayer>().frozen == false)
                    {
                        lose = false;
                    }
                }
                if (lose == true)
                {
                    SceneManager.LoadScene("TaggerWin");

                }
            }

        }
        if (time < 0)
        {
            SceneManager.LoadScene("PlayerWin");
            //players win
        }
    }

}
