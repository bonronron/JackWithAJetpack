using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levelnumber;
    public void StartGame(){
        SceneManager.LoadScene(levelnumber);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
