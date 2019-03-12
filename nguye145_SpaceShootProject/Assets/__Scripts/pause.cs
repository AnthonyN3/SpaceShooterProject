using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
	public bool paused;

    public GameObject pauseCanvas;

    void Start () {
	paused = false;
	}
	

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
				paused = !paused;			

		// or just do (pause)
		if (paused == true){
			Time.timeScale = 0;
			pauseCanvas.SetActive (true);

		}
		// or just do (!pause)
		else if (paused == false){
			Time.timeScale  = 1;
			pauseCanvas.SetActive(false); 
		}
	}
}
