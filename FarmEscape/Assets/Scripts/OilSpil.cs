using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpil : MonoBehaviour {
    protected const float timeout = 2;
    protected const float stiffnessReduction = 0.1f; ///Lose control
    protected float timerStarted;
    protected string affectedMaterialPath="Materials/OilSpiled";
    protected Material originalMat;
    protected float originalStiffnessFw;
    protected float originalStiffnessSide;
	// Use this for initialization
	void Start () {
        MeshRenderer carRenderer = GetComponentsInChildren<MeshRenderer>()[0];
        originalMat = GetComponentsInChildren<MeshRenderer>()[0].material;
        carRenderer.material = Resources.Load<Material>(affectedMaterialPath);

        originalStiffnessFw = GetComponentInChildren<WheelCollider>().forwardFriction.stiffness;
        originalStiffnessSide = GetComponentInChildren<WheelCollider>().sidewaysFriction.stiffness;

        WheelCollider[] wheelColliders = GetComponentsInChildren<WheelCollider>();
        for (int index = 0; index< wheelColliders.Length; ++index)
        {
            WheelFrictionCurve tempFriction = wheelColliders[index].forwardFriction;
            tempFriction.stiffness = tempFriction.stiffness * stiffnessReduction;
            wheelColliders[index].forwardFriction = tempFriction;

            tempFriction = wheelColliders[index].sidewaysFriction;
            tempFriction.stiffness = tempFriction.stiffness * stiffnessReduction;
            wheelColliders[index].sidewaysFriction = tempFriction;
        }
        timerStarted = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timerStarted > timeout)
        {
            Exit();
        }
	}

    private void Exit()
    {
        WheelCollider[] wheelColliders = GetComponentsInChildren<WheelCollider>();
        for (int index = 0; index < wheelColliders.Length; ++index)
        {
            WheelFrictionCurve tempFriction = wheelColliders[index].forwardFriction;
            tempFriction.stiffness = originalStiffnessFw;
            wheelColliders[index].forwardFriction = tempFriction;

            tempFriction = wheelColliders[index].sidewaysFriction;
            tempFriction.stiffness =originalStiffnessSide;
            wheelColliders[index].sidewaysFriction = tempFriction;
        }
        GetComponentsInChildren<MeshRenderer>()[0].material = originalMat;
        Destroy(this);
    }
}
