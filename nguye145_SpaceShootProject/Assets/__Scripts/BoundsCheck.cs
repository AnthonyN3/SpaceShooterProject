using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen
/// Note that this only works with orthographic Main Camera at [0,0,0]. 
/// </summary>

public class BoundsCheck : MonoBehaviour
{   

    [Header("Set in Inspector")]
    public float radius = 4f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;
    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    void Awake()        //page 685... they have it to start for some reason
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;  //main.aspect gives u the ration.. so width/height...therefore this gives u h*w/h = w
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if(pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }

        if (pos.x < -camWidth + radius) 
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        
        if (pos.y > camHeight - radius) 
        {   
            pos.y = camHeight - radius;
            offUp = true;
        }
        if (pos.y < -camHeight + radius) 
        {
            pos.y = -camHeight + radius;
            offDown = true;
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if(keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    //Draw the bounds in the Scene pane using OnDrawGizmos()
    //Basically draws the box camera in Scene view so you can see the boundaries
    void OnDrawGizmos()
    {
        if(!Application.isPlaying)
            return;
        
        Vector3 boundSize = new Vector3(camWidth*2, camHeight*2,0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
