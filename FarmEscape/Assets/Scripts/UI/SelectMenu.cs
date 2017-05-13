using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwipeInSwipeOut))]
public class SelectMenu : MonoBehaviour {
    SwipeInSwipeOut sIsO;
    protected IBackAble back;
    // Use this for initialization
    void Start () {
        sIsO = GetComponent<SwipeInSwipeOut>();
    }

    public void Appear(IBackAble backAction)
    {
        back = backAction;
        sIsO.SwipeIn();
    }

    public void Disappear()
    {
        back.Back();
        sIsO.SwipeOut();
    }
}
