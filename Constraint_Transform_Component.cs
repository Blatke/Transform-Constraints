// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.1.0 on March 20, 2024. 
// This is for implementing Constraint_Transform as a component.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constraint.Transform;

public class Constraint_Transform_Component : MonoBehaviour
{
    Constraint_Transform consTrans;
    public string constraintType = "r"; 
    /* 
        Type: 
        1."r" - rotation; 
        2."r2p" - rotation to position; 
        3."r2bx.0" - rotation at X axis to blend shape index[0].
    */
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
            // Debug.Log("Current object rotated: " + differenceBetweenTwoRotations);
            // Debug.Log("Target object rotated: " + consTrans.returnV3);

        }
    }
}