using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingerMovement : MonoBehaviour
{
    public float thrust = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("playing");
            GetComponent<Rigidbody>().AddForce(transform.forward * thrust, ForceMode.Impulse);
        }
    }
}
