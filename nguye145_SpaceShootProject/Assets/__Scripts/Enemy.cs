using System.Collections;       //Reqwuired for arrays and other collections
using System.Collections.Generic;   //for lists and dictionaries
using UnityEngine;  //for unity

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;   //the speed in m/s
    public float fireRate = 0.3f;   //seconds/show (unused)
    public float health = 10;
    public int score = 100; //points earned for destroying this 
    public float showDamageDuration = 0.1f;     // # seconds to show damage
    public float powerUpDropChance = 1f;    //Chance to drop a power-up

    [Header("Set Dynamically: Enemy")]
    public Color[] originalColors;
    public Material[] materials;// All the Materials of this & its children
    public bool showingDamage = false;
    public float damageDoneTime; // Time to stop showing damage
    public bool notifiedOfDestruction = false; // Will be used later

    protected BoundsCheck bndCheck;

    private Color currentColor;
    private bool isRed = false;


    private GameObject deathAudio;    //used to play the enemy death audio
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();

        deathAudio = GameObject.FindGameObjectWithTag("EnemyDestroyedAudio");

        //This is used to find what type of Enemy is being instantiated and its
        //corresponding colour the user chose
        currentColor = Color.white;
        if(gameObject.name == "Enemy_0(Clone)")
        {
            currentColor = Data.enemyColor[0];
        }
        else if(gameObject.name == "Enemy_1(Clone)")
        {
            currentColor = Data.enemyColor[1];
        }
        else if(gameObject.name == "Enemy_2(Clone)")
        {
            currentColor = Data.enemyColor[2];
        }
        else if(gameObject.name == "Enemy_3(Clone)")
        {
            currentColor = Data.enemyColor[3];
        }
        else if(gameObject.name == "Enemy_4(Clone)")
        {
            currentColor = Data.enemyColor[4];
        }

        //Used to change the ShowDamage to white
        if(currentColor == Color.red)
            isRed = true;
        
        //Get materials and colors for this GameObject and its children
        materials = Utils.GetAllMaterials( gameObject );
        originalColors = new Color[materials.Length];
        for( int i = 0 ; i < materials.Length ; i++)
        {
            //originalColors[i] = materials[i].color;       //(OLD CODE)
            originalColors[i] = currentColor;
        }
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

        if(showingDamage && Time.time > damageDoneTime)
        {
            UnShowDamage();
        }

        //If it isnt on screen then it will pass through this if statement
        if( bndCheck != null && bndCheck.offDown )
        {   
            Data.EnemiesOnScreenNow--;

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

    void OnCollisionEnter( Collision coll ) 
    { 
        GameObject otherGO = coll.gameObject;
        switch (otherGO.tag) 
        {
            case "ProjectilePlayer": 
                Projectile p = otherGO.GetComponent<Projectile>();
                // If this Enemy is off screen, don't damage it.
                if ( !bndCheck.isOnScreen ) 
                { 
                    Destroy( otherGO );
                    break;
                }
                // Hurt this Enemy
                ShowDamage();
                // Get the damage amount from the Main WEAP_DICT.
                health -= Main.GetWeaponDefinition(p.type).damageOnHit;
                if (health <= 0) 
                { 
                    //Tell te main singleton that this ship was destroyed
                    if(!notifiedOfDestruction)
                    {
                        Main.S.ShipDestroyed( this );
                    }
                    notifiedOfDestruction = true;
                    
                    //Adds score
                    if(gameObject.name == "Enemy_0(Clone)")
                    {
                        Data.Score += Data.pointsPerEnemy[0];
                        Data.enemyKilled[0] += 1;
                    }
                    else if(gameObject.name == "Enemy_1(Clone)")
                    {
                        Data.Score += Data.pointsPerEnemy[1];
                        Data.enemyKilled[1] += 1;
                    }
                    else if(gameObject.name == "Enemy_2(Clone)")
                    {
                        Data.Score += Data.pointsPerEnemy[2];
                        Data.enemyKilled[2] += 1;
                    }
                    else if(gameObject.name == "Enemy_3(Clone)")
                    {
                        Data.Score += Data.pointsPerEnemy[3];
                        Data.enemyKilled[3] += 1;
                    }
                    //NOTE: Enemy 4 is not included because Enemy_4 has its own OnCollisionScript 
                    //that overides this

                    Data.EnemiesOnScreenNow--;

                    //play the enemy death audio
                    deathAudio.GetComponent<EnemyKilledAudio>().PlayEnemyDeathAudio();
                    
                    // Destroy this Enemy
                    Destroy(this.gameObject);
                }
               
                Destroy( otherGO );
            break;

            default:
                print( "Enemy hit by non-ProjectilePlayer: " + otherGO.name ); 
            break;
        }
    }

    //Creates a visual as if the Enemy is being damaged (turns enemy red)
    void ShowDamage()
    { 

        foreach (Material m in materials) 
        {   
            if(isRed)
                m.color = Color.white;
            else
                m.color = Color.red;
        }
        showingDamage = true;
        damageDoneTime = Time.time + showDamageDuration;
    }

    //Changes the Enemy back to its original color
    void UnShowDamage() 
    { 
        /* for ( int i=0; i<materials.Length; i++ )
        {
            materials[i].color = originalColors[i];
        }
        showingDamage = false;
        */

        foreach(var renderer in gameObject.GetComponentsInChildren<Renderer>() )
        {
            renderer.material.color = currentColor;
        }
        showingDamage = false;

    }


   
}
