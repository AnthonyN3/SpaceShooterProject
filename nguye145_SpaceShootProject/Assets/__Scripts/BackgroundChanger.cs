using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public Texture [] backgroundImages;
    public GameObject starfieldBG_0;
    public GameObject starfieldBG_1;

    void Awake()
    {
        if(Data.whichBackground == 1)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = backgroundImages[0];
            gameObject.GetComponent<Parrallax>().enabled = false;
            starfieldBG_0.SetActive(false);
            starfieldBG_1.SetActive(false);
        } 
        else if(Data.whichBackground == 2)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = backgroundImages[1];
            gameObject.GetComponent<Parrallax>().enabled = false;
            starfieldBG_0.SetActive(false);
            starfieldBG_1.SetActive(false);
        }
        else if(Data.whichBackground == 3)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = backgroundImages[2];
            gameObject.GetComponent<Parrallax>().enabled = false;
            starfieldBG_0.SetActive(false);
            starfieldBG_1.SetActive(false);
        } //if none, it equals 0..so nothing
    }


}
