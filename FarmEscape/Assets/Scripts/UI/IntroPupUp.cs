using UnityEngine;
using System;

public class IntroPupUp : MonoBehaviour {
    public Sprite[] countdown;
    public GameObject button;

    protected const string levelAssetRoot = @"LevelAssets/";

    protected bool startCountDown;
    protected DateTime start;
    protected Sprite levelDescription;
    protected UnityEngine.UI.Image mainImage;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        levelDescription = Resources.Load<Sprite>(levelAssetRoot+"Level"+ UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex +"/LevelIntro/LevelIntro");
        mainImage = GetComponent<UnityEngine.UI.Image>();
        mainImage.sprite = levelDescription;
	}
	
	// Update is called once per frame
	void Update () {
        if (startCountDown)
        {
            double secondsPassed = (DateTime.Now - start).TotalSeconds;
            int secondsLeft = (int)((countdown.Length + 0.99d) - secondsPassed);
            if (secondsLeft == 0)
            {
                Time.timeScale = 1;
                gameObject.SetActive(false);
            }
            else
            {
                mainImage.sprite = countdown[secondsLeft - 1];
            }
        }

    }

    public void StartGame()
    {
        button.gameObject.SetActive(false);
        startCountDown = true;
        start = DateTime.Now;
    }
}
