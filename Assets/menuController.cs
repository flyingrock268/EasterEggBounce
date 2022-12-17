using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{

    [SerializeField] GameObject[] toggle;

    public void Play() {

        SceneManager.LoadScene("gameScene");
    
    }

    public void instructions() {

        foreach (GameObject obj in toggle) { 
        
            obj.SetActive(!obj.activeSelf);
        
        }
    
    }

    public void Quit() {

        Debug.Log("quit");
        Application.Quit();
    
    }

}
