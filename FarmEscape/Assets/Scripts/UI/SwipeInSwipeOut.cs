using UnityEngine;

public class SwipeInSwipeOut : MonoBehaviour {
    public Vector3 from;
    public Vector3 center;
    public Vector3 to;
    public int frames = 30;

    protected int startedAt = 0;
    protected Vector3 target;
    protected bool move;
    protected RectTransform transformRect;
    protected Vector3 increment;
	// Use this for initialization
	void Start () {
        transformRect = GetComponent<RectTransform>();
    }
	
    public void SwipeIn()
    {
        transformRect.localPosition = from;
        target = center;
        startedAt = Time.frameCount;
        move = true;

        increment = (target - transformRect.localPosition) / frames;
    }

    public void SwipeOut()
    {
        transformRect.localPosition = center;
        target = to;
        startedAt = Time.frameCount;
        move = true;

        increment = (target - transformRect.localPosition) / frames;
    }

	// Update is called once per frame
	void Update ()
    {
		if (move)
        {
            if (Time.frameCount - startedAt < frames)
            {
                transformRect.localPosition += increment;
            }else
            {
                move = false;
            }
        }
	}
}
