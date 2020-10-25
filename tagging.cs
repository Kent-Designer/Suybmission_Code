using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagging : MonoBehaviour
{
    public float freezeRange;
    public Transform center;
    public LayerMask whatIsPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(center.position, freezeRange, whatIsPlayer))
        {
            Collider2D[] taggedPlayers = Physics2D.OverlapCircleAll(center.position, freezeRange, whatIsPlayer);
            for (int i = 0; i < taggedPlayers.Length; i++)
            {
                taggedPlayers[i].GetComponent<controlerPlayer>().frozen = true;
            }
        }
    }
    void OnDrawGizmosSelected()//visualizes hitbox
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(center.position, freezeRange);
    }

}
