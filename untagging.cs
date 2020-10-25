using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class untagging : MonoBehaviour
{
    public float freezeRange;
    public Transform left;
    public Transform right;
    
    public LayerMask whatIsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(left.position, freezeRange, whatIsPlayer))
        {
            Collider2D[] taggedPlayers = Physics2D.OverlapCircleAll(left.position, freezeRange, whatIsPlayer);
            for (int i = 0; i < taggedPlayers.Length; i++)
            {
                taggedPlayers[i].GetComponent<controlerPlayer>().frozen = false;
            }
        }
        if (Physics2D.OverlapCircle(right.position, freezeRange, whatIsPlayer))
        {
            Collider2D[] taggedPlayers = Physics2D.OverlapCircleAll(right.position, freezeRange, whatIsPlayer);
            for (int i = 0; i < taggedPlayers.Length; i++)
            {
                taggedPlayers[i].GetComponent<controlerPlayer>().frozen = false;
            }
        }

    }
    void OnDrawGizmosSelected()//visualizes hitbox
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(left.position, freezeRange);
        Gizmos.DrawWireSphere(right.position, freezeRange);

    }
}
