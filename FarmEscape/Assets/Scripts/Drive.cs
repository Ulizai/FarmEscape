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

    public List<AxelInfo> motorAxels;
    public List<AxelInfo> freeAxels;
    public float maxMotorTorque; 
    public float maxSteeringAngle;

    protected Rigidbody theRigid;

    void Start () {
        theRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    private void FixedUpdate()
    {
        float motor = maxMotorTorque; ///AutoAccelerate
        ///Steer
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxelInfo axleInfo in motorAxels)
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
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

        foreach(AxelInfo axelInfo in freeAxels)
        {
            ApplyLocalPositionToVisuals(axelInfo.leftWheel);
            ApplyLocalPositionToVisuals(axelInfo.rightWheel);
        }

        theRigid.AddForce(Vector3.down * theRigid.velocity.magnitude*500);

    }
}
