using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	public void Next()
    {
        Time.timeScale = 1;
        int nextLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel == Application.levelCount)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
