using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMenuMangager : MonoBehaviour
{


    public void BronzeMax(string value)
    {
        GameObject go = GameObject.Find("InputField MaxEnemies Bronze");
        int x = int.Parse(value);

        //value cannot be negative
        if(x <= 0)
        {
            go.GetComponent<TMP_InputField>().text = "1";
            Data.onScreenBronze = 1;
        }
        else if ( x >= Data.onScreenSilver)
        {
            go.GetComponent<TMP_InputField>().text = (Data.onScreenSilver-1).ToString();
            Data.onScreenBronze = Data.onScreenSilver-1;    
        }
        else
        {
            Data.onScreenBronze = x;
        }

    }

    public void SilverMax(string value)
    {
        GameObject go = GameObject.Find("InputField MaxEnemies Silver");
        int x = int.Parse(value);

        //value cannot be negative or be less than max screen on bronze level
        //We will automatically make the value +1 more than bronze levels max
        if(x <= Data.onScreenBronze )
        {
            go.GetComponent<TMP_InputField>().text = (Data.onScreenBronze+1).ToString();
            Data.onScreenSilver = Data.onScreenBronze+1;
        } 
        else if (x >= Data.onScreenGold)
        {
            go.GetComponent<TMP_InputField>().text = (Data.onScreenGold-1).ToString();
            Data.onScreenSilver = Data.onScreenGold-1;    
        }
        else
        {
            Data.onScreenSilver = x;    
        }

    }

    public void GoldMax(string value)
    {
        GameObject go = GameObject.Find("InputField MaxEnemies Gold");
        int x = int.Parse(value);

        //value cannot be negative or be less than max screen on Gold level
        //We will automatically make the value +1 more than Gold levels max
        if(x <= Data.onScreenSilver)
        {
            go.GetComponent<TMP_InputField>().text = (Data.onScreenSilver+1).ToString();
            Data.onScreenGold = Data.onScreenSilver+1;
        }
        else
        {
            Data.onScreenGold = x;
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
        Data.isEnemySilver[0] = isActive;
    }
    public void GoldE1 (bool isActive)
    {
        Data.isEnemySilver[1] = isActive;
    }
    public void GoldE2 (bool isActive)
    {
        Data.isEnemySilver[2] = isActive;
    }
    public void GoldE3 (bool isActive)
    {
        Data.isEnemySilver[3] = isActive;
    }
    public void GoldE4 (bool isActive)
    {
        Data.isEnemySilver[4] = isActive;
    }




}
