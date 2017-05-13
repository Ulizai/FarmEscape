using UnityEngine;

public class LevelProgressManager : MonoBehaviour {
    public int checkPoints = 3;
    public int mustHaveInViewCheckpoints = 2;
    public float[] times;

    public GameObject[] stars;
    protected bool[] checkpointsCrossed;
    protected GameObject[] checkpointObjects;
    protected CameraController cameraControl;
    protected Timer timer;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString(PlayerPrefKeys.LAST_LEVEL, UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        FadeToBlack ftb = FindObjectOfType<FadeToBlack>();
        if (ftb)
        {
            ftb.UnFade();
        } 

        if (checkPoints > TagManager.CHECKPOINTS.Length)
        {
            Debug.LogError("You are trying to use more checkpoints than created, please create more checkpoint objects and tags");
        }

        cameraControl = FindObjectOfType<CameraController>();
        timer = FindObjectOfType<Timer>();

        checkpointsCrossed = new bool[checkPoints];
        checkpointObjects = new GameObject[checkPoints];
        for (int index = 0; index < checkPoints;++index)
        {
            checkpointsCrossed[index] = false;
            checkpointObjects[index] = GameObject.FindGameObjectWithTag(TagManager.CHECKPOINTS[index]);
        }

        stars = new GameObject[TagManager.STARS.Length];
        for (int index = 0; index < stars.Length; ++index)
        {
            stars[index] = GameObject.FindGameObjectWithTag(TagManager.STARS[index]);
        }

        GameObject[] mushHaveInViewObjects = new GameObject[mustHaveInViewCheckpoints];
        for (int index = 0; index< mustHaveInViewCheckpoints; ++index)
        {
            mushHaveInViewObjects[index] = checkpointObjects[index];
        }

        cameraControl.mustHaveInView = mushHaveInViewObjects;
    }
	
    public void CheckpointCrossed(int checkpointIndex)
    {
        Debug.Log("Crossed "+checkpointIndex);
        bool allPreviousPassed = true;
        for (int index = 0; index<checkpointIndex;++index)
        {
            if (!checkpointsCrossed[index])
            {
                allPreviousPassed = false;
                break;
            }
        }

        if ((allPreviousPassed)&&(!checkpointsCrossed[checkpointIndex]))
        {
            checkpointsCrossed[checkpointIndex] = true;
            if (checkpointIndex == checkpointsCrossed.Length - 1)
            {
                Win(timer.GetCurrent());
            }
        }
        else
        {
            return;
        }

        GameObject[] newList = null;
        if (checkpointIndex + mustHaveInViewCheckpoints < checkpointObjects.Length)
        {
            newList = new GameObject[mustHaveInViewCheckpoints];
            for (int index = 1; index < mustHaveInViewCheckpoints;++index)
            {
                newList[index - 1] = checkpointObjects[checkpointIndex + index];
            }
            newList[checkpointIndex + mustHaveInViewCheckpoints - 1] = checkpointObjects[checkpointIndex + mustHaveInViewCheckpoints];
        }
        else
        {
            newList = new GameObject[cameraControl.mustHaveInView.Length - 1];
            for (int index = 0; index<newList.Length;++index)
            {
                newList[index] = cameraControl.mustHaveInView[index + 1];
            }
        }
        cameraControl.mustHaveInView = newList;
    }
    public void Paused(bool newState)
    {
        if (newState)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    protected void Win(float winTime)
    {
        timer.Stopped = true;
        int starCount = stars.Length;
        for (int index = 0; index < stars.Length - 1; ++index)
        {
            if (winTime < times[index])
            {
                break;
            }
            else
            {
                --starCount;
            }
        }
        Debug.Log("And you win : " + starCount);
    }

	void Update () {
        if (!timer.Stopped)
        {
            float currentTime = timer.GetCurrent();
            for (int index = 0; index < stars.Length - 1; ++index)
            {
                if (currentTime > times[index])
                {
                    stars[index].SetActive(false);
                }
                else
                {
                    break;
                }
            }
        }
	}
}
