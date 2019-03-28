using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMenuMangager : MonoBehaviour
{
    //Takes the boolean Toggle for selecting which Enemy will spawn for each scene
    public Toggle [] bronzeEnemiesSelected;
    public Toggle [] silverEnemiesSelected;
    public Toggle [] goldEnemiesSelected;
    
    public TMP_InputField bronzeMaxInputField; 
    public TMP_InputField silverMaxInputField;
    public TMP_InputField goldMaxInputField;

    public TMP_InputField bronzeScoreInputField;
    public TMP_InputField silverScoreInputField;
    public TMP_InputField goldScoreInputField;

    void Awake()
    {
        //Initialize items based on th Data static script 
        for(int i = 0; i < 5; i++)
        {
            bronzeEnemiesSelected[i].isOn = Data.isEnemyBronze[i];
            silverEnemiesSelected[i].isOn = Data.isEnemySilver[i];
            goldEnemiesSelected[i].isOn = Data.isEnemyGold[i];
        }

        bronzeMaxInputField.text = Data.onScreenBronze.ToString();
        silverMaxInputField.text = Data.onScreenSilver.ToString();
        goldMaxInputField.text = Data.onScreenGold.ToString();

        bronzeScoreInputField.text = Data.scoreToWin[0].ToString();
        silverScoreInputField.text = Data.scoreToWin[1].ToString();
        goldScoreInputField.text = Data.scoreToWin[2].ToString();

    }

    public void BronzeMax(string value)
    {
        //GameObject go = GameObject.Find("InputField MaxEnemies Bronze");
        int x = int.Parse(value);

        //value cannot be negative
        if(x <= 0)
        {
            //go.GetComponent<TMP_InputField>().text = "1";
            bronzeMaxInputField.text = "1";
            Data.onScreenBronze = 1;
        }
        else if ( x >= Data.onScreenSilver)
        {
            //go.GetComponent<TMP_InputField>().text = (Data.onScreenSilver-1).ToString();
            bronzeMaxInputField.text = (Data.onScreenSilver-1).ToString();
            Data.onScreenBronze = Data.onScreenSilver-1;    
        }
        else
        {
            Data.onScreenBronze = x;
        }

    }

    public void SilverMax(string value)
    {
        int x = int.Parse(value);

        //value cannot be negative or be less than max screen on bronze level
        //We will automatically make the value +1 more than bronze levels max
        if(x <= Data.onScreenBronze )
        {
            silverMaxInputField.text = (Data.onScreenBronze+1).ToString();
            Data.onScreenSilver = Data.onScreenBronze+1;
        } 
        else if (x >= Data.onScreenGold)
        {
            silverMaxInputField.text = (Data.onScreenGold-1).ToString();
            Data.onScreenSilver = Data.onScreenGold-1;    
        }
        else
        {
            Data.onScreenSilver = x;    
        }

    }
    public void GoldMax(string value)
    {
        int x = int.Parse(value);

        //value cannot be negative or be less than max screen on Gold level
        //We will automatically make the value +1 more than Gold levels max
        if(x <= Data.onScreenSilver)
        {
            goldMaxInputField.text = (Data.onScreenSilver+1).ToString();
            Data.onScreenGold = Data.onScreenSilver+1;
        }
        else
        {
            Data.onScreenGold = x;
        }
    }

    public void BronzeScoreToWin(string value)
    {   
        //GameObject go = GameObject.Find("InputField ScoreToWin Bronze");
        int x = int.Parse(value);

        //Score cannot be negative be lower than 0
        if(x <= 0)
        {
            //go.GetComponent<TMP_InputField>().text = 1.ToString();
            bronzeScoreInputField.text = 1.ToString();
            Data.scoreToWin[0] = 1;
        }
        else if( x >= Data.scoreToWin[1])
        {
            bronzeScoreInputField.text = (Data.scoreToWin[1]-1).ToString();
            Data.scoreToWin[0] = Data.scoreToWin[1]-1;
        }
        else
        {
            Data.scoreToWin[0] = x;
        }
    }
    public void SilverScoreToWin(string value)
    {   
        int x = int.Parse(value);

        //Score cannot be lower than bronze's score
        if(x <= Data.scoreToWin[0])
        {
            silverScoreInputField.text = (Data.scoreToWin[0]+1).ToString();
            Data.scoreToWin[1] = Data.scoreToWin[0]+1;
        }
        else if( x >= Data.scoreToWin[2])   //cant be higher than Gold score
        {
            silverScoreInputField.text = (Data.scoreToWin[2]-1).ToString();
            Data.scoreToWin[1] = Data.scoreToWin[2]-1;
        }
        else
        {
            Data.scoreToWin[1] = x;
        }
    }
    public void GoldScoreToWin(string value)
    {   
        int x = int.Parse(value);

        //Score cannot be negative or 0
        if(x <= Data.scoreToWin[1])
        {
            goldScoreInputField.text = (Data.scoreToWin[1]+1).ToString();
            Data.scoreToWin[2] = Data.scoreToWin[1]+1;
        }
        else
        {
            Data.scoreToWin[2] = x;
        }
    }


    public void BronzeE0 (bool isActive)
    {
        Data.isEnemyBronze[0] = isActive;
    }
    public void BronzeE1 (bool isActive)
    {
        Data.isEnemyBronze[1] = isActive;
    }
    public void BronzeE2 (bool isActive)
    {
        Data.isEnemyBronze[2] = isActive;
    }
    public void BronzeE3 (bool isActive)
    {
        Data.isEnemyBronze[3] = isActive;
    }
    public void BronzeE4 (bool isActive)
    {
        Data.isEnemyBronze[4] = isActive;
    }

    public void SilverE0 (bool isActive)
    {
        Data.isEnemySilver[0] = isActive;
    }
    public void SilverE1 (bool isActive)
    {
        Data.isEnemySilver[1] = isActive;
    }
    public void SilverE2 (bool isActive)
    {
        Data.isEnemySilver[2] = isActive;
    }
    public void SilverE3 (bool isActive)
    {
        Data.isEnemySilver[3] = isActive;
    }
    public void SilverE4 (bool isActive)
    {
        Data.isEnemySilver[4] = isActive;
    }

    public void GoldE0 (bool isActive)
    {
        Data.isEnemyGold[0] = isActive;
    }
    public void GoldE1 (bool isActive)
    {
        Data.isEnemyGold[1] = isActive;
    }
    public void GoldE2 (bool isActive)
    {
        Data.isEnemyGold[2] = isActive;
    }
    public void GoldE3 (bool isActive)
    {
        Data.isEnemyGold[3] = isActive;
    }
    public void GoldE4 (bool isActive)
    {
        Data.isEnemyGold[4] = isActive;
    }




}
