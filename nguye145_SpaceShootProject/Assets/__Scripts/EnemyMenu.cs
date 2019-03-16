using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMenu : MonoBehaviour
{   
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
