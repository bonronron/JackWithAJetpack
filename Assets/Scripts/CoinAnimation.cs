using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 100f;
    public Rigidbody rb;
    float yVal;
    // Update is called once per frame
    void Start() {
        rb = this.GetComponent<Rigidbody>();    
        yVal = transform.position.y;
    }
    void Update()
    {
        float angle = rotateSpeed * Time.deltaTime;
        transform.Rotate(1.0f,angle,0.0f, Space.World);
    }   
    //Mathf.Sin(Time.time) * floatStrength
}
