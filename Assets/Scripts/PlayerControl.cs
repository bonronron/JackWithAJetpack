using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3.0f;
    private float verticalVelocity;
    public float jumpForce = 6.0f;
    public Rigidbody rb;
    public int fuel = 10;
    public int fuellimit = 300;
    public bool onGround; 

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        Move();
        if(Input.GetKey(KeyCode.Space)){
            Jump();
        }
        Refuel();
        onGround = IsGrounded();
        rb.AddForce(-transform.up*1.1f,ForceMode.Force);
    }
    void Move(){
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical") ;
        Vector3 newpos = transform.forward * deltaZ + transform.right*deltaX;
        rb.MovePosition(transform.position + newpos.normalized * speed * Time.deltaTime);
    }
    void Jump(){
        if(fuel>0){
            rb.AddForce(transform.up * jumpForce, ForceMode.Acceleration);
            fuel--;
        }
    }
    public bool IsGrounded(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit,0.5f)){
            return true;
        }
        return false;
    }
    void Refuel(){
        if(onGround && fuel< fuellimit){
            fuel++;
        }
    }

}
