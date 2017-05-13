using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
    protected FadeToBlack ftb;

    private void Awake()
    {
        ftb = FindObjectOfType<FadeToBlack>();
    }

    public void LoadSelectedLevel()
    {
        FindObjectOfType<SelectMenu>().Disappear();
        FindObjectOfType<PauseMenu>().Disappear();
        Pause pause = FindObjectOfType<Pause>();
        if (pause)
        {
            pause.UnPause();
        }
        ftb.StartFade(() => UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.name));
    }
}
