using System.Collections;       //Reqwuired for arrays and other collections
using System.Collections.Generic;   //for lists and dictionaries
using UnityEngine;  //for unity

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;   //the speed in m/s
    public float fireRate = 0.3f;   //seconds/show (unused)
    public float hleath = 10;
    public int score = 100; //points earned for destroying this 
    protected BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    //This is a property: A method that acts like a field
    public Vector3 pos 
    {
        get
        {
            return(this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();

        //If it isnt on screen then it will pass through this if statement
        if( bndCheck != null && bndCheck.offDown )
        {   
            //if so, gets deleted
            Destroy (gameObject);
        }
    }

    public virtual void Move() 
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter( Collision coll)
    {
        GameObject otherGO = coll.gameObject;

        if( otherGO.tag == "ProjectilePlayer")
        {
            Destroy( otherGO ); //destroy the projectile
            Destroy( gameObject );  //Destroy this Enemy GameObject
        } 
        else 
        {
            print( "Enemy hit by non-ProjectileHero: " + otherGO.name);
        }
    }
   
}
