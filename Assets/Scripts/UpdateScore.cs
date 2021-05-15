using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public GameObject Score;
    public GameObject Time;
    public GameObject ScoreGUI;
    public GameObject ScoreBoard;
    private GameObject[] gateways;
    private TextMeshPro ScoreBoardTxt;
    public float time;
    public int score;
    private string timestr;
    
    private void Start() {
        ScoreBoardTxt = ScoreBoard.GetComponent<TextMeshPro>();
    }

    private void OnTriggerEnter(Collider other) {
        GameObject collider = other.gameObject;
        
        if(other.tag == "Player"){
            timestr = Time.GetComponent<Timer>().timeString; 
            score = Score.GetComponent<Score>().score;
            time = Time.GetComponent<Timer>().time;

            if (GetHighScore(score,time,timestr)){
                ScoreBoardTxt.text = "NEW HIGHSCORE!\nCurrent :\n  Time :"+timestr+" \n  Score:"+score+" \nBest:\n Time :"+PlayerPrefs.GetString("timeStr","0")+"\n Score: "+PlayerPrefs.GetString("scoreStr","0");
            }

            else{
                ScoreBoardTxt.text = ScoreBoardTxt.text = "Current :\n  Time :"+timestr+" \n  Score:"+score+" \nBest:\n Time :"+PlayerPrefs.GetString("timeStr","0")+"\n Score: "+PlayerPrefs.GetString("scoreStr","0");
            }

            OpenGateways(true);
            Destroy(gameObject);
            Destroy(Time);
            Destroy(ScoreGUI);
            
        }

    }

    private bool GetHighScore(float score,float time,string timestr){
        float best = PlayerPrefs.GetFloat("BestScore",0.0f);
        float current = score/time;
        if (current > best)  {
            PlayerPrefs.SetFloat("BestScore",current);
            PlayerPrefs.SetString("scoreStr",score.ToString());
            PlayerPrefs.SetString("timeStr",timestr);
            return true;
        }
        return false;
    }

    private void OpenGateways(bool change){
        gateways = GameObject.FindGameObjectsWithTag("LevelGates");
        foreach (GameObject gateway in gateways)
        {
           if(change){
               Destroy(gateway);
           }

        }
    }
}
