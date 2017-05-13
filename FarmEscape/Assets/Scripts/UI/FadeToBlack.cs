using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeToBlack : MonoBehaviour {

    public int frames = 30;

    protected int startedAt = 0;
    protected RawImage image;
    protected bool fading = false;
    protected System.Action whenDone;
    // Use this for initialization
    void Start () {
        image = GetComponent<RawImage>();
        gameObject.SetActive(false);
	}

    public void StartFade(System.Action whenDone)
    {
        startedAt = Time.frameCount;
        fading = true;
        this.whenDone = whenDone;
        gameObject.SetActive(true);
    }

    public void UnFade()
    {
        image.color = new Color(0, 0, 0, 0);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update ()
    {
        if (fading)
        {
            if (Time.frameCount - startedAt < frames)
            {
                image.color = new Color(0, 0, 0, 1f*(Time.frameCount - startedAt) / frames);
            }
            else
            {
                fading = false;
                DoneFade();
            }
        }
	}

    private void DoneFade()
    {
        whenDone();
    }
}
