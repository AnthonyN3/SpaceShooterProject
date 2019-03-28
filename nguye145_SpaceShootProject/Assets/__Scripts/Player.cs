using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player S; //this is a singleton (only one instance of this object)

    [Header("Set in Insepctor")]
    //These fields control movement of the ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameRestartDelay = 4f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    public Weapon[] weapons;

    [Header("Set Dynamically")]
    [SerializeField]
    private float  _shieldLevel1 = 1; //remember the underscore
    private GameObject lastTriggerGo = null;    //This variable holds a reference to the last triggering GameObject
    public delegate void WeaponFireDelegate();
    public WeaponFireDelegate fireDelegate;


    void Start()
    {   
        //If there are 2 heros with this script, and it tries to assign S to another instance
        //of Hero, then it will cause an error (because we only want once instance of hero, hence the use of Singelton S)
        if(S == null)
        {
            S = this;

            //Reset the weapons to start _Player with 1 blaster
            ClearWeapons();
            weapons[0].SetType(WeaponType.blaster);
        } else
        {
            Debug.LogError("Player.Awake() - Attempted to assign seecond Player.S!");
        }
    }

    void Update()
    {
        //Pull in information from the input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //Change transofrm.position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;
    
        //Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis*pitchMult, xAxis*rollMult,0);

        if (Input.GetAxis("Jump") == 1 && fireDelegate != null) 
        {
            fireDelegate();
        }
    }

    //This way of shooting projectiles is not used anymore
    /* void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        
        Projectile proj = projGO.GetComponent<Projectile>();
        proj.type = WeaponType.blaster;
        float tSpeed = Main.GetWeaponDefinition( proj.type ).velocity;
        rigidB.velocity = Vector3.up * tSpeed;

    }*/


    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        
        //Make sure it's not the same triggering "go"(GameObject variable name) as last time (since the "Enemy" object contains nested objects)
        //So when a wing or the sphere of the plane is triggered it doesnt register it has two seperate triggers causing you to loose 2 shields a time... 
        if(go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if (go.tag == "Enemy")
        {
            Data.EnemiesOnScreenNow--; 

            shieldLevel1--; //decreases the level of the shield by 1
            Destroy(go);    // destroys the enemy gameObject after it makes contact with hero
        } 
        else if(go.tag == "PowerUp")
        {
            //if this shield was triggered by a PowerUp
            AbsorbPowerUp(go);
        }
        else if(go.tag == "ProjectileEnemy")
        {
            Destroy(go);
            Destroy(gameObject);
        }
        else
        {
            print("Triggered by non Enemy: " +go.name);
        }
    }

    public void AbsorbPowerUp(GameObject go)
    {
        PowerUp pu = go.GetComponent<PowerUp>();

        switch(pu.type)
        {
            case WeaponType.shield: 
                shieldLevel1++;
            break;
            
            default: 
                if (pu.type == weapons[0].type) 
                { // If it is the same type 
                    Weapon w = GetEmptyWeaponSlot();
                    if (w != null) 
                    {
                        // Set it to pu.type
                        w.SetType(pu.type);
                    }
                } 
                else
                { // If this is a different weapon type 
                    ClearWeapons();
                    weapons[0].SetType(pu.type);
                }
            break;
        }
        pu.AbsorbedBy(this.gameObject);
    }


    public float shieldLevel1
    {
        get
        { 
            return(_shieldLevel1);
        }

        set
        {
            _shieldLevel1 = Mathf.Min(value, 4);
            //if the shield is going to be set to less than zero
            if (value < 0)
            {
                Destroy(this.gameObject);

                //this tells Main.s to restart the game after a delay
                Main.S.DelaayedRestart(gameRestartDelay);
            }
        }
    }

    Weapon GetEmptyWeaponSlot() 
    {
        for (int i=0; i<weapons.Length; i++) 
        {
            if ( weapons[i].type == WeaponType.none ) 
            {
                return( weapons[i] );
            }
        }
        return( null );
    }
    void ClearWeapons() 
    {
        foreach (Weapon w in weapons) 
        {
            w.SetType(WeaponType.none);
        }
    }

}
