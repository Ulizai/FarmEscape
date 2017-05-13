using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour {

    public float totalTime;

    protected float start;
    protected bool stopped;
    protected Text uiText;

    public void SetTimerStart()
    {
        start = Time.time;
        uiText = GetComponent<Text>();
        stopped = false;
    }

    public bool Stopped
    {
        set { stopped = value; }
        get { return stopped; }
    }

    public float GetCurrent()
    {
        return (int)((Time.time - start) * 100) / 100f;
    }

	// Use this for initialization
	void Start () {
        SetTimerStart();
	}
	
	// Update is called once per frame
	void Update () {
        if (!stopped)
        {
            uiText.text = ((int)((Time.time - start) * 100) / 100f).ToString();
        }
	}
}
