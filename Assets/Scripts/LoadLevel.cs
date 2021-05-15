using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int levelnumber = 0;
    private void OnTriggerEnter(Collider other) {
        GameObject collider = other.gameObject;
        //Debug.Log("Collided");
        if(other.tag == "Player"){
            //Debug.Log("Player detected");
            SceneManager.LoadScene(levelnumber);
        }
    }
}
