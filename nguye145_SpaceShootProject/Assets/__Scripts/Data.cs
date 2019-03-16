using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will be used to store variables/info to be passed between scenes
public static class Data
{
    public static int Score = 0;
    public static int [] enemyKilled = {0,0,0,0,0};

    //Stores the values for enemies on screen
    public static int onScreenBronze = 3;
    public static int onScreenSilver = 5;
    public static int onScreenGold = 10;

    //Stores the types of enemies for each level (Levels: Bronze, Silver, and gold)
    //index[0] == Enemy_0 , index[1] == Enemy_1... etc
    public static bool [] isEnemyBronze = {true,true,true,false,false};
    public static bool [] isEnemySilver = {true,true,true,true,false};
    public static bool [] isEnemyGold = {true,true,true,true,true};

    //Stores score limit need to complete each level
    //[0] - Bronze level, [1] - Silver level, [2] - Gold level
    public static int [] scoreToWin = {50, 100, 150};
 
    //Stores the score gained for the destruction of each enemy (enemy 0,1,2,3 and 4)
    public static int [] pointsPerEnemy = {5,10,15,20,25};
    //public static string [] enemyColor = {"white","white","white","white","white"};
    public static Color [] enemyColor = {Color.white, Color.white, Color.white, Color.white, Color.white};


}
