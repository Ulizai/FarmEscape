using UnityEngine;

public class Ice : MonoBehaviour {

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.left * 20000, transform.position - transform.forward, ForceMode.Impulse);
        Destroy(this);
    }
}
