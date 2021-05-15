using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthbar;
    private float fuel;
    private float fuellimit;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuel = player.GetComponent<PlayerControl>().fuel;
        fuellimit = player.GetComponent<PlayerControl>().fuellimit;
        healthbar.fillAmount = fuel/fuellimit;
        
    }
}
