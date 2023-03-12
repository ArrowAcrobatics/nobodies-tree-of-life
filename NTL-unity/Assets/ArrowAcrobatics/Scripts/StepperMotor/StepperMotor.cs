using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepperMotor : MonoBehaviour
{
    public int motorId;
    public enum Direction
    {
        X, Y, Z
    }
    public Direction animationDirection;

    [Tooltip("This position can be animated.")]
    [Range(0, 1)]
    public float position; 

    public void ForceLowerbound() { 
        Debug.Log("ForceLowerbound");
    }
    public void ForceUpperBound() {
        Debug.Log("ForceUpperBound");
    }

    [Tooltip("Sets upper bound and lower bound to exactly this position.")]
    public void ResetBounds() { 
        Debug.Log("ResetBounds"); 
    }

    public void FixedUpdate() {

    }
}
