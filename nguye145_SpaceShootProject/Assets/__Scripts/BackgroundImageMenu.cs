using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundImageMenu : MonoBehaviour
{
    
    public GameObject [] Backgrounds;
    public TMP_Dropdown dropDownPicker;
    
    
    private static int dropDownValue;

    void Awake()
    {
        dropDownPicker.value = dropDownValue;
    }
    

    public void ChangeBackground(int value)
    {   
        dropDownValue = value;
        if(value == 0)
        {
            Backgrounds[0].SetActive(false);
            Backgrounds[1].SetActive(false);
            Backgrounds[2].SetActive(false);
        }
        else if(value == 1)
        {
            Backgrounds[0].SetActive(true);
            Backgrounds[1].SetActive(false);
            Backgrounds[2].SetActive(false);
        }
        else if(value == 2)
        {
            Backgrounds[0].SetActive(false);
            Backgrounds[1].SetActive(true);
            Backgrounds[2].SetActive(false);
        }
        else if(value == 3)
        {
            Backgrounds[0].SetActive(false);
            Backgrounds[1].SetActive(false);
            Backgrounds[2].SetActive(true);
        }
    }
}
