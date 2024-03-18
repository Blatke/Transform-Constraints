// v0.1.3 on March 18, 2024.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constraint.Transform;

public class marginTransformGet : MonoBehaviour
{
    Constraint_Transform consTrans;
    public string constraintType = "r"; //Type: 1."r" - rotation; 2."r2p" - rotation to position;
    public GameObject TargetGameObject; // Another gameobject besides the current one that will be used as the target to which the changes in transform of the current gameobject are about to transfer. 
    public float weight = 1.0f; 
    public bool inverted = false;
    public bool isActive = true; 
    public string axisStandard = "X=X";
    public bool targetXFixed = false, targetYFixed = false, targetZFixed = false; 
    Vector3 oldRotation;
    Vector3 newRotation;
    Vector3 differenceBetweenTwoRotations;
    void Start()
    {
        oldRotation = this.transform.eulerAngles;
    }

    void Update()
    {

        newRotation = this.transform.eulerAngles;
        if (newRotation != new Vector3(0f,0f,0f))
        {
            differenceBetweenTwoRotations = newRotation - oldRotation;
            oldRotation = newRotation;
        }
        
    }
    
    void LateUpdate()
    {
        if (differenceBetweenTwoRotations != new Vector3(0f,0f,0f))
        {
            consTrans.trans (constraintType, differenceBetweenTwoRotations, TargetGameObject, weight, inverted, isActive, axisStandard, targetXFixed, targetYFixed, targetZFixed);
            Debug.Log("Current object rotated: " + differenceBetweenTwoRotations);
            Debug.Log("Object B rotated: " + consTrans.returnV3);

        }
    }
}
