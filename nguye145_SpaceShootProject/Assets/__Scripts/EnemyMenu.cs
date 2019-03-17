using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyMenu : MonoBehaviour
{   
    public TMP_Dropdown [] pointsDropDown;
    public TMP_Dropdown [] colorsDropDown;

    void Awake()
    {
        int temp;
        int temp2;
        
        //For points
        for(int i = 0 ; i < 5; i++)
        {
            if(Data.pointsPerEnemy[i] == 5)
                temp = 0;
            else if(Data.pointsPerEnemy[i] == 10)
                temp = 1;
            else if(Data.pointsPerEnemy[i] == 15)
                temp = 2;
            else if(Data.pointsPerEnemy[i] == 20)
                temp = 3;
            else
                temp = 4;

            if(Data.enemyColor[i] == Color.white)
                temp2 = 0;
            else if(Data.enemyColor[i] == Color.red)
                temp2 = 1;
            else if(Data.enemyColor[i] == Color.green)
                temp2 = 2;
            else
                temp2 = 3;

            pointsDropDown[i].value = temp;
            colorsDropDown[i].value = temp2;
        }
    }

    public void PtsEnemy0(int value)
    {   
        if(value == 0)
            Data.pointsPerEnemy[0] = 5;
        else if(value == 1)
            Data.pointsPerEnemy[0] = 10;
        else if(value == 2)
            Data.pointsPerEnemy[0] = 15;
        else if(value == 3)
            Data.pointsPerEnemy[0] = 20;
        else if(value == 4)
            Data.pointsPerEnemy[0] = 25;    
    }
    public void PtsEnemy1(int value)
    {   
        if(value == 0)
            Data.pointsPerEnemy[1] = 5;
        else if(value == 1)
            Data.pointsPerEnemy[1] = 10;
        else if(value == 2)
            Data.pointsPerEnemy[1] = 15;
        else if(value == 3)
            Data.pointsPerEnemy[1] = 20;
        else if(value == 4)
            Data.pointsPerEnemy[1] = 25;    
    }
    public void PtsEnemy2(int value)
    {   
        if(value == 0)
            Data.pointsPerEnemy[2] = 5;
        else if(value == 1)
            Data.pointsPerEnemy[2] = 10;
        else if(value == 2)
            Data.pointsPerEnemy[2] = 15;
        else if(value == 3)
            Data.pointsPerEnemy[2] = 20;
        else if(value == 4)
            Data.pointsPerEnemy[2] = 25; 
    }
    public void PtsEnemy3(int value)
    {   
        if(value == 0)
            Data.pointsPerEnemy[3] = 5;
        else if(value == 1)
            Data.pointsPerEnemy[3] = 10;
        else if(value == 2)
            Data.pointsPerEnemy[3] = 15;
        else if(value == 3)
            Data.pointsPerEnemy[3] = 20;
        else if(value == 4)
            Data.pointsPerEnemy[3] = 25; 
    }
    public void PtsEnemy4(int value)
    {   
        if(value == 0)
            Data.pointsPerEnemy[4] = 5;
        else if(value == 1)
            Data.pointsPerEnemy[4] = 10;
        else if(value == 2)
            Data.pointsPerEnemy[4] = 15;
        else if(value == 3)
            Data.pointsPerEnemy[4] = 20;
        else if(value == 4)
            Data.pointsPerEnemy[4] = 25; 
    }
    
    public void ColorEnemy0(int value)
    {   
        if(value == 0)
            Data.enemyColor[0] = Color.white;
        else if(value == 1)
            Data.enemyColor[0] = Color.red;
        else if(value == 2)
            Data.enemyColor[0] = Color.green;
        else if(value == 3)
            Data.enemyColor[0] = Color.blue;
    }

    public void ColorEnemy1(int value)
    {   
        if(value == 0)
            Data.enemyColor[1] = Color.white;
        else if(value == 1)
            Data.enemyColor[1] = Color.red;
        else if(value == 2)
            Data.enemyColor[1] = Color.green;
        else if(value == 3)
            Data.enemyColor[1] = Color.blue;
    }

    public void ColorEnemy2(int value)
    {   
        if(value == 0)
            Data.enemyColor[2] = Color.white;
        else if(value == 1)
            Data.enemyColor[2] = Color.red;
        else if(value == 2)
            Data.enemyColor[2] = Color.green;
        else if(value == 3)
            Data.enemyColor[2] = Color.blue;
    }

    public void ColorEnemy3(int value)
    {   
        if(value == 0)
            Data.enemyColor[3] = Color.white;
        else if(value == 1)
            Data.enemyColor[3] = Color.red;
        else if(value == 2)
            Data.enemyColor[3] = Color.green;
        else if(value == 3)
            Data.enemyColor[3] = Color.blue;
    }

    public void ColorEnemy4(int value)
    {   
        if(value == 0)
            Data.enemyColor[4] = Color.white;
        else if(value == 1)
            Data.enemyColor[4] = Color.red;
        else if(value == 2)
            Data.enemyColor[4] = Color.green;
        else if(value == 3)
            Data.enemyColor[4] = Color.blue;
    }

}
