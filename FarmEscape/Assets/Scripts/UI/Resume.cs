using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

	public void OnResumePressed()
    {
        FindObjectOfType<Pause>().UnPause(); //Should not store, Pause.cs should be persistent...for now
        FindObjectOfType<PauseMenu>().Disappear();
    }
}
