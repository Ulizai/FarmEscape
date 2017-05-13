using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwipeInSwipeOut))]
public class PauseMenu : MonoBehaviour {

    protected SwipeInSwipeOut sIsO;
	// Use this for initialization
	void Start () {
        sIsO = GetComponent<SwipeInSwipeOut>();
	}
	

    public void Appear()
    {
        sIsO.SwipeIn();
    }

    public void Disappear()
    {
        sIsO.SwipeOut();
    }
}
