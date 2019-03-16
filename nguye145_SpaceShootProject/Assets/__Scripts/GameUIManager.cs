using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI E0Text;
    public TextMeshProUGUI E1Text;
    public TextMeshProUGUI E2Text;
    public TextMeshProUGUI E3Text;
    public TextMeshProUGUI E4Text;


    void Update()
    {   
        //NOTE: since we started with a string, we dont need to add ToString() at the end of the ints
        scoreText.text = "Score:" + Data.Score;
        E0Text.text = "E0: " + Data.enemyKilled[0];
        E1Text.text = "E1: " + Data.enemyKilled[1];
        E2Text.text = "E2: " + Data.enemyKilled[2];
        E3Text.text = "E3: " + Data.enemyKilled[3];
        E4Text.text = "E4: " + Data.enemyKilled[4];

    }


}
