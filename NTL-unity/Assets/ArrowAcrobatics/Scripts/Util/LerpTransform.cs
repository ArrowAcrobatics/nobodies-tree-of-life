using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArrowAcrobatics.TransformExtensions;

/**
 * Places this gameobjects transform in between two targets.
 * This uses global position data.
 */
public class LerpTransform : MonoBehaviour
{
    public Transform from;
    public Transform to;
    
    [Tooltip("Animate this value for extra coolness.")]
    public float lerpVal;

    public bool affectPosition = true;
    public bool affectRotation = true;
    public bool clamp = true;

    void FixedUpdate()
    {
        if (from == null || to == null)
        {
            return;
        }

        TransformData fromDat = from.GlobalData();
        TransformData toDat = to.GlobalData();
        TransformData myDat = transform.GlobalData();

        if (affectPosition) {
            myDat.position = Vector3.Lerp(fromDat.position, toDat.position, lerpVal);
        }

        if (affectPosition) {
            myDat.rotation = Quaternion.Lerp(fromDat.rotation, toDat.rotation, lerpVal);
        }

        if(affectPosition || affectRotation)
        {
            transform.Set(myDat);
        }
    }
}
