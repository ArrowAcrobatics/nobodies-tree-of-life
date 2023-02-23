using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicRotator : MonoBehaviour
{
    public float degPerSec = 60;
    Vector3 axis = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(degPerSec * Time.deltaTime, axis);
    }
}
