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
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Header("Set Dynamically")]
    [SerializeField]
    private float  _shieldLevel1 = 1; //remember the underscore
    private GameObject lastTriggerGo = null;    //This variable holds a reference to the last triggering GameObject

    void Awake()
    {   
        //If there are 2 heros with this script, and it tries to assign S to another instance
        //of Hero, then it will cause an error (because we only want once instance of hero, hence the use of Singelton S)
        if(S == null)
        {
            S = this;
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

        //Allow the ship to fire
        if( Input.GetKey( KeyCode.Space) )
        {
            TempFire();
        }

        void TempFire()
        {
            GameObject projGO = Instantiate<GameObject>(projectilePrefab);
            projGO.transform.position = transform.position;
            Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
            rigidB.velocity = Vector3.up*projectileSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        //print("Triggered" + go.name);

        //Make sure it's not the same triggering "go"(GameObject variable name) as last time (since the "Enemy" object contains nested objects)
        //So when a wing or the sphere of the plane is triggered it doesnt register it has two seperate triggers causing you to loose 2 shields a time... 
        if(go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if (go.tag == "Enemy")
        {
            shieldLevel1--; //decreases the level of the shield by 1
            Destroy(go);    // destroys the enemy gameObject after it makes contact with hero
        } 
        else
        {
            print("Triggered by non Enemy: " +go.name);
        }
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
}
