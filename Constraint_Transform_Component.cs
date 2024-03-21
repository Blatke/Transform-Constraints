// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.1.0.3 on March 22, 2024. 
// This is for implementing Constraint_Transform as a component.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constraint.Transform;

public class Constraint_Transform_Component : MonoBehaviour
{
    Constraint_Transform consTrans;

    [Header("Basic")]
    
    [Tooltip("1. \"r\": A's rotation to B's rotation;\n2. \"r2p\": A's rotation to B's position;\n3. \"r2bx.0\": A's rotation at x axis to B's blendshape with index[0].")]
    public string constraintType = "r"; 
    /* 
        Type: 
        1."r" - rotation; 
        2."r2p" - rotation to position; 
        3."r2bx.0" - rotation at X axis to blend shape index[0].
    */
    [Tooltip("Assign the gameobject to be affected.")]
    public GameObject TargetGameObject; // Another gameobject besides the current one that will be used as the target to which the changes in transform of the current gameobject are about to transfer. 
    [Tooltip("To what extend A's changes affect B.")]
    public float weight = 1.0f; 
    [Tooltip("Whether or not the values of changes transferred from A to B are multiplied by -1.0.")]
    public bool inverted = false;
    [Tooltip("Check it to activiate this component.")]
    public bool isActive = true; 

    [Header("Limitation")]
    [Tooltip("1. \"X=X\": A's changes at X,Y,Z axes are respectively transferred to B's value at X,Y,Z axes;\n2. \"X=Y\": A's changes at X,Y,Z axes are respectively transferred to B's value at Y,Z,X axes;\n3. \"X=Z\": A's changes at X,Y,Z axes are respectively transferred to B's value at Z,X,Y axes.")]
    public string axisStandard = "X=X";
    [Tooltip("Check it to block the changes at this axis transferred to B.")]
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
        if (this.gameObject.GetInstanceID() != TargetGameObject.gameObject.GetInstanceID())
        {
            if (differenceBetweenTwoRotations != new Vector3(0f,0f,0f))
            {
                consTrans.trans (constraintType, differenceBetweenTwoRotations, TargetGameObject, weight, inverted, isActive, axisStandard, targetXFixed, targetYFixed, targetZFixed);
                // Debug.Log("Current object rotated: " + differenceBetweenTwoRotations);
                // Debug.Log("Target object rotated: " + consTrans.returnV3);

            }
        }
    }
}