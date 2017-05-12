using UnityEngine;

public class CrossCheckpoint : MonoBehaviour {
    LevelProgressManager lpm;
    private void Start()
    {
        lpm = FindObjectOfType<LevelProgressManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            lpm.CheckpointCrossed(int.Parse(tag.Split(' ')[1])-1);
        }catch 
        {
            Debug.LogError("You might have forgotten to tag the element : "+ gameObject.name);
        }
    }
}
