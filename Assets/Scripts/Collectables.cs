using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Player"){
            GameObject player = collider.gameObject; 
            player.GetComponent<Score>().score +=1;
            player.GetComponent<Score>().UpdateScore();
            Destroy(gameObject);
        }
    }

}
