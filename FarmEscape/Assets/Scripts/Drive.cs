using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

    [System.Serializable]
    public class AxelInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor; 
        public bool steering; 
    }

    public List<AxelInfo> axelInfos; 
    public float maxMotorTorque; 
    public float maxSteeringAngle; 

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxelInfo axleInfo in axelInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}
