using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject fadeOutObject;
    protected LevelProgressManager lpm;
    protected PauseMenu pauseMenu;

	// Use this for initialization
	void Start () {
        lpm = FindObjectOfType<LevelProgressManager>();
        pauseMenu = FindObjectOfType<PauseMenu>();
	}
	
	public void PauseGame()
    {
        fadeOutObject.SetActive(true);
        lpm.Paused(true);
        pauseMenu.Appear();
    }

    public void UnPause()
    {
        lpm.Paused(false);
        fadeOutObject.SetActive(false);
    }
}
