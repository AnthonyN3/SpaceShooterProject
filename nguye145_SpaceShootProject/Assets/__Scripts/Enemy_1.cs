﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy_1 extends Enemy class
public class Enemy_1 : Enemy
{
    [Header("Set in Inspector: Enemy_1")]
    public float waveFrequency = 2; //# seconds for a full swine wave
    public float waveWidth = 4; //sine wave width in meters
    public float waveRotY = 45;

    private float x0;   //The intial x value of pos
    private float birthTime;

    //Start works well because it's not used by the Enemy superclass
    void Start()
    {
        // set x0 to the initial x position of Enemy_1
        x0 = pos.x;

        birthTime = Time.time;
    }

    //Overide the Move function on superclass Enemy
    public override void Move()
    {
        //because pos is a property, you cannot directly set pos.x
        //So get the pos as an editable Vector3
        Vector3 tempPos = pos;
        
        //Theta adjust based on time
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        // rotate a bit about y
        Vector3 rot = new Vector3(0, sin*waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        // base.Move() still handles the movement down in y
        base.Move();
       
    }
}