using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepperMotor : MonoBehaviour
{
    public int motorId;

    public void ForceLowerbound() { 
        Debug.Log("ForceLowerbound");
    }
    public void ForceUpperBound() {
        Debug.Log("ForceUpperBound");
    }
    public void ResetBounds() { 
        Debug.Log("ResetBounds"); 
    }
}
