using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public Animator animator;
    public Renderer jetpack;
    private bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        onGround = GetComponent<PlayerControl>().IsGrounded();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("IsRunning");
        bool isFlying = animator.GetBool("IsFlying");
        onGround = GetComponent<PlayerControl>().IsGrounded();
        //bool startFlying = animator.GetBool(startFlyingHash);
        bool flying = Input.GetKey(KeyCode.Space);
        bool moving = (Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical")!=0);
        if(!isRunning && moving){
            animator.SetBool("IsRunning",true);
        }
        if(isRunning && !moving){
            animator.SetBool("IsRunning",false);
        }
        if(flying && !isFlying){
            animator.SetBool("IsFlying",true);
            jetpack.enabled = true; 
        }
        if(isFlying && onGround){
            animator.SetBool("IsFlying",false);
            jetpack.enabled = false;
        }

    }
}
