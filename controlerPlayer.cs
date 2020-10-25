using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player;
using Mirror;


public class controlerPlayer : NetworkBehaviour
{
    public LayerMask whatIsPlayer;
    public float speed=40;
    public float jumpForce;
    public string moveAxis;
    public string jumpButton;
    public Transform rightWallCheck;
    public Transform leftWallCheck;
    public float wallRange;
    public LayerMask whatIsWall;
    public Transform floorCheck;
    public float floorRange;
    public LayerMask whatIsFloor;
    public bool frozen=false;
    private bool facingRight=true;

    Vector3 stuff = Vector3.zero;
    Runner runny;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
        body = this.GetComponent<Rigidbody2D>();
        if (!isLocalPlayer)
        {
            body.isKinematic = true;
            return;
        }
        runny = new Runner(speed, jumpForce, moveAxis, jumpButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        
        
        if (!frozen)
        {
            if (Physics2D.OverlapCircle(floorCheck.position, floorRange, whatIsFloor))
            {
                Jump();
            }
            else if (Physics2D.OverlapCircle(floorCheck.position, floorRange, whatIsPlayer))
            {
                Jump();
            }
            else if (Physics2D.OverlapCircle(leftWallCheck.position, wallRange, whatIsWall))
            {
                WallJump(1);
            }
            else if (Physics2D.OverlapCircle(rightWallCheck.position, wallRange, whatIsWall))
            {
                WallJump(-1);
            }
            if (Input.GetAxisRaw(moveAxis) < 0 && facingRight)
                facingRight = false;
            else if (Input.GetAxisRaw(moveAxis) > 0 && !facingRight)
                facingRight = true;
        }


    }
    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {

            return;
        }
        if (!frozen)
        {
            runny.Move(Time.deltaTime, body);

        }
        
    }
    void Jump()
    {
        if (Input.GetButtonDown(jumpButton))
        {
            body.velocity *= new Vector2(1, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    void WallJump(int direction)
    {
        //Debug.Log(1);
        if (Input.GetButtonDown(jumpButton))
        {
            body.velocity *= new Vector2(1, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((jumpForce/2)*direction, jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnDrawGizmosSelected()//visualizes hitbox
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rightWallCheck.position,wallRange);
        Gizmos.DrawWireSphere(leftWallCheck.position, wallRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(floorCheck.position, floorRange);



    }
}
