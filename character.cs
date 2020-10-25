using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
namespace player
{
    public class Runner
    {
        public float speed;
        public float jumpForce;
        public string moveAxis;
        public string jumpButton;
        Vector3 stuff = Vector3.zero;
        public float smoothTime = 0.3F;
        public Runner(float speedLocal, float jumpForceLocal, string moveAxisLocal, string jumpButtonLocal)
        {
            speed = speedLocal;
            jumpForce = jumpForceLocal;
            moveAxis = moveAxisLocal;
            jumpButton = jumpButtonLocal;
        }
        public void Move(float timeDelta, Rigidbody2D body)
        {
           
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2((speed*Input.GetAxisRaw(moveAxis)*timeDelta) * 10f, body.velocity.y);
            // And then smoothing it out and applying it to the character
            body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref stuff, smoothTime);
        }
        //public void Jump()
        //{
        //    if (Input.GetButtonDown(jumpButton))
        //    {

        //    }
        //}

    } 
    public class character : MonoBehaviour
    {

  
    }
}
