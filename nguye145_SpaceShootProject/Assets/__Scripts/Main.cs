using System.Collections;   //for arrays and other collections
using System.Collections.Generic;   //for using lists dictionaries
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main S;   //a singleton for Main
    static Dictionary<WeaponType, WeaponDefinition> WEAP_DICT;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;  //array of enemy prefabs
    public float enemySpawnPerSecond = 0.5f;    //# Enemies/second
    public float enemyDefaultPadding = 1.5f; //padding for position
    public WeaponDefinition[] weaponDefinitions;
    public GameObject prefabPowerUp; 
    public WeaponType[] powerUpFrequency = new WeaponType[] { 
    WeaponType.blaster, WeaponType.blaster,
    WeaponType.spread, WeaponType.shield };

    private BoundsCheck bndCheck;


    [Header("Game Audio")]
    public AudioClip playerDeath;
    public AudioClip gameOver;

    public void ShipDestroyed( Enemy e ) 
    {
        // Potentially generate a PowerUp
        if (Random.value <= e.powerUpDropChance) 
        { 
            // Choose which PowerUp to pick
            // Pick one from the possibilities in powerUpFrequency
            int ndx = Random.Range(0,powerUpFrequency.Length);
            WeaponType puType = powerUpFrequency[ndx];
            // Spawn a PowerUp
            GameObject go = Instantiate( prefabPowerUp ) as GameObject;
            PowerUp pu = go.GetComponent<PowerUp>();
            // Set it to the proper WeaponType
            pu.SetType( puType );
            // Set it to the position of the destroyed ship
            pu.transform.position = e.transform.position;
        }
    }  

    void Awake()
    {
        S = this;
        //Set bndCheck to reference the BoundsCheck component on this gameObject(on the camera)
        bndCheck = GetComponent<BoundsCheck>();

        //Invoke SpawnEnemy() once (in 2 seconds, based on default vales)
        Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);

        //A generic Dictionary with WeaponType as the key
        WEAP_DICT = new Dictionary<WeaponType, WeaponDefinition>();
        foreach( WeaponDefinition def in weaponDefinitions)
        {
            WEAP_DICT[def.type] = def;
        }

        //Also used to reset Data when player dies
        for(int i = 0 ; i < 5; i++)
        {
            Data.enemyKilled[i] = 0;
        }
        Data.Score = 0;
        Data.EnemiesOnScreenNow = 0;
    }

    public void SpawnEnemy()
    {
        //Pick a random Enemy prefab to instantiate (also based of which Level)
        int ndx = 0;
        GameObject []prefabEnemiesNew = new GameObject[10];
        
        if(SceneManager.GetActiveScene().name == "BronzeLevel" )
        {   
            int x = 0;
            for(int i = 0 ; i < Data.isEnemyBronze.Length ; i++)
            {
                if(Data.isEnemyBronze[i])
                {   
                    if(i == 0)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[0];
                        prefabEnemiesNew[x+1] = prefabEnemies[1];
                        prefabEnemiesNew[x+2] = prefabEnemies[2];
                        x += 3;
                    }
                    else if (i == 1)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[3];
                        prefabEnemiesNew[x+1] = prefabEnemies[4];
                        x += 2;
                    }
                    else if (i == 2)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[5];
                        prefabEnemiesNew[x+1] = prefabEnemies[6];
                        x += 2;
                    }
                    else if(i == 3)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[7];
                        prefabEnemiesNew[x+1] = prefabEnemies[8];
                        x += 2;
                    }
                    else if(i == 4)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[9];
                        x++;
                    }      
                }
            }
            
            int EnemiesNum = 0;
            for(int i = 0 ; prefabEnemiesNew[i] != null; i++)
            {
                EnemiesNum++;
            }
            
            ndx = Random.Range(0, EnemiesNum);
        }
        else if(SceneManager.GetActiveScene().name == "SilverLevel" )
        {   
            int x = 0;
            for(int i = 0 ; i < Data.isEnemySilver.Length ; i++)
            {
                if(Data.isEnemySilver[i])
                {   
                    if(i == 0)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[0];
                        prefabEnemiesNew[x+1] = prefabEnemies[1];
                        prefabEnemiesNew[x+2] = prefabEnemies[2];
                        x += 3;
                    }
                    else if (i == 1)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[3];
                        prefabEnemiesNew[x+1] = prefabEnemies[4];
                        x += 2;
                    }
                    else if (i == 2)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[5];
                        prefabEnemiesNew[x+1] = prefabEnemies[6];
                        x += 2;
                    }
                    else if(i == 3)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[7];
                        prefabEnemiesNew[x+1] = prefabEnemies[8];
                        x += 2;
                    }
                    else if(i == 4)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[9];
                        x++;
                    }      
                }
            }
            
            int EnemiesNum = 0;
            for(int i = 0 ; prefabEnemiesNew[i] != null; i++)
            {
                EnemiesNum++;
            }
            
            ndx = Random.Range(0, EnemiesNum);
        }
        else if(SceneManager.GetActiveScene().name == "GoldLevel" )
        {   
            int x = 0;
            for(int i = 0 ; i < Data.isEnemyGold.Length ; i++)
            {
                if(Data.isEnemyGold[i])
                {   
                    if(i == 0)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[0];
                        prefabEnemiesNew[x+1] = prefabEnemies[1];
                        prefabEnemiesNew[x+2] = prefabEnemies[2];
                        x += 3;
                    }
                    else if (i == 1)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[3];
                        prefabEnemiesNew[x+1] = prefabEnemies[4];
                        x += 2;
                    }
                    else if (i == 2)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[5];
                        prefabEnemiesNew[x+1] = prefabEnemies[6];
                        x += 2;
                    }
                    else if(i == 3)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[7];
                        prefabEnemiesNew[x+1] = prefabEnemies[8];
                        x += 2;
                    }
                    else if(i == 4)
                    {
                        prefabEnemiesNew[x] = prefabEnemies[9];
                        x++;
                    }      
                }
            }
            
            int EnemiesNum = 0;
            for(int i = 0 ; prefabEnemiesNew[i] != null; i++)
            {
                EnemiesNum++;
            }
            
            ndx = Random.Range(0, EnemiesNum);
        }

        GameObject go = Instantiate<GameObject>( prefabEnemiesNew[ ndx ] );
        Data.EnemiesOnScreenNow++;

        int colorIndex = 0;
        if(go.name == "Enemy_0(Clone)")
            colorIndex = 0;
        else if(go.name == "Enemy_1(Clone)")
            colorIndex = 1;
        else if(go.name == "Enemy_2(Clone)")
            colorIndex = 2;
        else if(go.name == "Enemy_3(Clone)")
            colorIndex = 3;
        else if(go.name == "Enemy_4(Clone)")
            colorIndex = 4;

        foreach(var renderer in go.GetComponentsInChildren<Renderer>() )
        {   
            renderer.material.color = Data.enemyColor[colorIndex];    
        }

        //Position the Enemy above the screen with a random x position
        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null )
        {
            enemyPadding = Mathf.Abs( go.GetComponent<BoundsCheck>().radius);
        }

        //Set the initial position for the spawned enemy
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range( xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;


        if(GameUIManager.isWin)
        {
            return;
        }

        //Checks the maximum allowed enemies on screen depending on which level player is on
        if(SceneManager.GetActiveScene().name == "BronzeLevel" )
        {
            if(Data.EnemiesOnScreenNow < Data.onScreenBronze)
                Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
            else
                StartCoroutine(AddEnemyWhenFree(Data.onScreenBronze));
        }
        else if(SceneManager.GetActiveScene().name == "SilverLevel")
        {
            if(Data.EnemiesOnScreenNow < Data.onScreenSilver)
                Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
            else
                StartCoroutine(AddEnemyWhenFree(Data.onScreenSilver));
        }
        else if(SceneManager.GetActiveScene().name == "Goldlevel")
        {
            if(Data.EnemiesOnScreenNow < Data.onScreenGold)
                Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
            else
                StartCoroutine(AddEnemyWhenFree(Data.onScreenGold));
        }
    
    }

    //Adds a enemy only when max number of enemies are not on the screen
    IEnumerator AddEnemyWhenFree(int MaxEnemyOnScreen)
    {
        //while(isMaxEnemy) yield return null;
        while(Data.EnemiesOnScreenNow >= MaxEnemyOnScreen) yield return null;
        {
            Invoke("SpawnEnemy", 1f/enemySpawnPerSecond);
        }
    }


    public void DelaayedRestart( float delay)
    {
        //Invoke the Restart() method in delay secods
        Invoke( "Restart", delay);
    }

    public void Restart()
    {
        if(SceneManager.GetActiveScene().name == "BronzeLevel")
            SceneManager.LoadScene("BronzeLevel");
        else if(SceneManager.GetActiveScene().name == "SilverLevel")
            SceneManager.LoadScene("SilverLevel");
        else if(SceneManager.GetActiveScene().name == "GoldLevel")
            SceneManager.LoadScene("GodlLevel");
    }

    /// <summary>
    /// Static function that gets a WeaponDefinition from the WEAP_DICT
    /// protected field of the Main class.
    /// </summary>
    /// <returns>The WeaponDefinition or, if there is no WeaponDefinition with
    /// the WeaponType passed in, returns a new WeaponDefinition with a
    /// WeaponType of none..</returns>
    /// <param name="wt">The WeaponType of the desired WeaponDefinition</param>
    static public WeaponDefinition GetWeaponDefinition( WeaponType wt ) 
    {

    // Check to make sure that the key exists in the Dictionary
    // Attempting to retrieve a key that didn't exist, would throw an error,
    // so the following if statement is important.
    if (WEAP_DICT.ContainsKey(wt)) 
    { 
        return( WEAP_DICT[wt] );
    }

    // This returns a new WeaponDefinition with a type of WeaponType.none,
    // which means it has failed to find the right WeaponDefinition
    return( new WeaponDefinition() ); // c

    }


}
