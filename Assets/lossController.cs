using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lossController : MonoBehaviour
{

    [SerializeField] Text score;
    [SerializeField] Text highScore;
    [SerializeField] GameObject newHighScore;

    // Start is called before the first frame update
    void Start()
    {

        if (!PlayerPrefs.HasKey("highScore") || PlayerPrefs.GetInt("highScore") < PlayerPrefs.GetInt("score")) {

            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("score"));
            newHighScore.SetActive(true);
                
        }

        score.text = "Your Score: " + PlayerPrefs.GetInt("score").ToString();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();

    }

    public void quit() { 
    
        Application.Quit();
    
    }

    public void playAgain() {

        SceneManager.LoadScene("gameScene");
    
    }

    public void menu() {

        SceneManager.LoadScene("start");

    }

}
