using UnityEngine;

public class LevelProgressManager : MonoBehaviour {
    public int checkPoints = 3;
    public int mustHaveInViewCheckpoints = 2;

    protected bool[] checkpointsCrossed;
    protected GameObject[] checkpointObjects;
    protected CameraController cameraControl;

	// Use this for initialization
	void Start () {
        if (checkPoints > TagManager.CHECKPOINTS.Length)
        {
            Debug.LogError("You are trying to use more checkpoints than created, please create more checkpoint objects and tags");
        }

        checkpointsCrossed = new bool[checkPoints];
        checkpointObjects = new GameObject[checkPoints];
        for (int index = 0; index < checkPoints;++index)
        {
            checkpointsCrossed[index] = false;
            checkpointObjects[index] = GameObject.FindGameObjectWithTag(TagManager.CHECKPOINTS[index]);
        }

        cameraControl = FindObjectOfType<CameraController>();

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

        if (allPreviousPassed)
        {
            checkpointsCrossed[checkpointIndex] = true;
            if (checkpointIndex == checkpointsCrossed.Length - 1)
            {
                Win();
            }
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

    protected void Win()
    {
        Debug.Log("And you win");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
