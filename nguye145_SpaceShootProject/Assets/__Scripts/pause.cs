using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
	public bool paused;

    public GameObject pauseCanvas;

    void Start () 
	{
		paused = false;
	}
	

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
				paused = !paused;			

		if (paused)
		{
			Time.timeScale = 0;
			pauseCanvas.SetActive (true);

		}
		else if (!paused && !GameUIManager.isWin)
		{

			Time.timeScale  = 1;
			pauseCanvas.SetActive(false); 
		}
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
