using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;
using UnityEditor.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI E0Text;
    public TextMeshProUGUI E1Text;
    public TextMeshProUGUI E2Text;
    public TextMeshProUGUI E3Text;
    public TextMeshProUGUI E4Text;


    public TextMeshProUGUI timeText;
    private Stopwatch timer;

    //Used to check which level we are on, 0, 1 or 2
    private int LevelIndex;

    //For Time.timeScale = 0 to work in this script
    //Since we call Time.timeScale = 1 in the pause script
    public static bool isWin = false; 


    private GameObject winGameAudio;
    void Awake()
    {
        winGameAudio = GameObject.FindGameObjectWithTag("WinAudio");
        isWin = false;
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "BronzeLevel")
            LevelIndex = 0;
        else if(SceneManager.GetActiveScene().name == "SilverLevel")
            LevelIndex = 1;
        else if(SceneManager.GetActiveScene().name == "GoldLevel")
            LevelIndex = 2;


        timer = new Stopwatch();
        timer.Start();
    }  

    void Update()
    {   
        //NOTE: since we started with a string, we dont need to add ToString() at the end of the ints
        scoreText.text = "Score:" + Data.Score + "/" + Data.scoreToWin[LevelIndex];
        E0Text.text = "E0: " + Data.enemyKilled[0];
        E1Text.text = "E1: " + Data.enemyKilled[1];
        E2Text.text = "E2: " + Data.enemyKilled[2];
        E3Text.text = "E3: " + Data.enemyKilled[3];
        E4Text.text = "E4: " + Data.enemyKilled[4];
        timeText.text = timer.Elapsed.Seconds + " s";

        //Checks if you reached max score (you win)
        if(Data.Score >= Data.scoreToWin[LevelIndex] && !isWin )
        {   
            isWin = true;
            timer.Stop();
            winGameAudio.GetComponent<ClearStageAudio>().PlayWinAudio();
            Invoke("Win", 2);
        }

    }

    public void Win()
    {
        isWin = false;
        if(SceneManager.GetActiveScene().name == "GoldLevel")
            SceneManager.LoadScene(0);      //same as loading menu
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }


}
