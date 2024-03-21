// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.2.0 on March 22, 2024. 
// This is for implementing Constraint_Transform as a component.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constraint.Transform;

namespace Constraint.Transform.Component
{

public class Constraint_Transform_Component : MonoBehaviour
{
    public enum constraintTypeOptions{
        A_rotation_to_B_rotation,
        A_rotation_to_B_position,
        A_rotation_to_B_blendshape
    }

    public static Dictionary<constraintTypeOptions, string> cTypeToString = new Dictionary<constraintTypeOptions, string>()
    {
        { constraintTypeOptions.A_rotation_to_B_rotation, "r2r" },
        { constraintTypeOptions.A_rotation_to_B_position, "r2p" },
        { constraintTypeOptions.A_rotation_to_B_blendshape, "r2b" }
    };

    public enum axisStandardOptions{
        X_to_X,
        X_to_Y,
        X_to_Z
    }

    public static Dictionary<axisStandardOptions, string> axisToString = new Dictionary<axisStandardOptions, string>()
    {
        {axisStandardOptions.X_to_X, "X=X"},
        {axisStandardOptions.X_to_Y, "X=Y"},
        {axisStandardOptions.X_to_Z, "X=Z"}
    };

    Constraint_Transform consTrans;

    [Header("Basic")]

    [Tooltip("Assign the gameobject to be affected.\nThe current gameobject is called A;\nThe target one is called B.")]
    public GameObject TargetGameObject; // Another gameobject besides the current one that will be used as the target to which the changes in transform of the current gameobject are about to transfer. 

    [Tooltip("Choose the way that A's transform changes affects B.\nWhen it refers to blendshape, supplement options need to be focused.")]
    public constraintTypeOptions constraintType;  

    string constraintTypeOption; 
    /* 
        Type: 
        1."r" - rotation; 
        2."r2p" - rotation to position; 
        3."r2bx.0" - rotation at X axis to blend shape index[0].
    */

    [Tooltip("To what extend A's changes affect B.")]
    public float weight = 1.0f; 
    [Tooltip("Whether or not the values of changes transferred from A to B are multiplied by -1.0.")]
    public bool inverted = false;
    [Tooltip("Check it to activiate this component.")]
    public bool isActive = true; 

    [Header("Supplements")]
    [Tooltip("1. \"X to X\": A's changes at X,Y,Z axes are respectively transferred to B's value at X,Y,Z axes;\n2. \"X to Y\": A's changes at X,Y,Z axes are respectively transferred to B's value at Y,Z,X axes;\n3. \"X to Z\": A's changes at X,Y,Z axes are respectively transferred to B's value at Z,X,Y axes.\nThis option is NOT for B's blendshape.")]
    public axisStandardOptions axisStandard;
    string axisStandardChoosen;
    [Tooltip("Check it to block the changes at this axis transferred to B.\nThe first unchecked axis affects B's blendshape.")]
    public bool targetXFixed = false, targetYFixed = false, targetZFixed = false; 
    [Tooltip("Assign which blendshape of B's is affected.\nThis option is NOT for other constraint types.")]
    public int blendshapeIndex = 0;
    Vector3 oldRotation;
    Vector3 newRotation;
    Vector3 differenceBetweenTwoRotations;
    void Start()
    {
        oldRotation = this.transform.eulerAngles;
        Debug.Log(cTypeToString[constraintType]);
        Debug.Log(axisToString[axisStandard]);
    }

    void Update()
    {

        newRotation = this.transform.eulerAngles;
        if (newRotation != new Vector3(0f,0f,0f))
        {
            differenceBetweenTwoRotations = newRotation - oldRotation;
            oldRotation = newRotation;
            constraintTypeOption = cTypeToString[constraintType];
            if (constraintTypeOption == "r2b")
            {
                constraintTypeOption += "." + blendshapeIndex;
            }
            axisStandardChoosen = axisToString[axisStandard];
        }
        
    }
    
    void LateUpdate()
    {
        if (this.gameObject.GetInstanceID() != TargetGameObject.gameObject.GetInstanceID())
        {
            if (differenceBetweenTwoRotations != new Vector3(0f,0f,0f))
            {                
                consTrans.trans (constraintTypeOption, differenceBetweenTwoRotations, TargetGameObject, weight, inverted, isActive, axisStandardChoosen, targetXFixed, targetYFixed, targetZFixed);
                // Debug.Log("Current object rotated: " + differenceBetweenTwoRotations);
                // Debug.Log("Target object rotated: " + consTrans.returnV3);

            }
        }else{
            Debug.Log("The target gameobject and the current gameobject are exactly the same one.\nPlease change to another gameobject as the target to be affected.");
        }
    }
}

}