using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNow : MonoBehaviour
{
    protected FadeToBlack ftb;
    private void Awake()
    {
        ftb = FindObjectOfType<FadeToBlack>();
    }

    public void StartOrContinue()
    {
        if (PlayerPrefs.HasKey(PlayerPrefKeys.LAST_LEVEL))
        {
            ftb.StartFade(()=>UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString(PlayerPrefKeys.LAST_LEVEL)));
        }else
        {
            ftb.StartFade(()=>UnityEngine.SceneManagement.SceneManager.LoadScene("Level1")); //start
        }
      
    }
}
