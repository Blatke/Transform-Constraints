// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.1.4 on March 22, 2024. 
// This is for changing a designated gameobject's transform, such as rotation, by using a vector.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universal.DegreeNormalize;
using Universal.XYZAlternate;
using Universal.XYZFixed;

namespace Constraint.Transform
{
public struct Constraint_Transform
{
    public Vector3 returnV3;//Return a vector variable to let it know what it newly changes (after calculating weights, inversion, etc).
    public void trans (string type, Vector3 marginA, GameObject b, float weight, bool inverted, bool isActive, string axisStandard, bool fixedX, bool fixedY, bool fixedZ)
    {
        // marginA is the additional rotation of Gameobject A (this).
        if (b != null & type != null)
        {
            type = type.ToLower();
            if (isActive)
            {
                Universal_DegreeNormalize dnl;
                marginA = dnl.d(marginA);
                marginA *= weight;
                

                if (inverted)
                {
                    marginA *= -1;
                }

                Universal_XYZAlternate xyzAlt;
                marginA = xyzAlt.d(marginA, axisStandard);

                Universal_XYZFixed xyzFix;
                marginA = xyzFix.d(marginA, fixedX, fixedY, fixedZ);

                switch (type){
                    case "r": // Rotation to rotation.
                    case "r2r":
                        b.transform.localEulerAngles += marginA;
                        break;                        
                    case "r2p": // Rotation to position.
                        b.transform.localPosition += marginA;
                        break;
                    default:
                        break;
                }    

                if (type.Length>=4)
                {
                    if (type.Substring(0,3) == "r2b") // Rotation to Blend Shape. e.g.: r2bx.0 where x means x's value affects blendshape; 0 means the index number of the blendshape to be affected.
                    {
                        if(b.TryGetComponent<SkinnedMeshRenderer>(out var skinnedMeshRenderer))
                        {
                            // string axis2Bls = type.Substring(3,1);
                            // string axis2Bls;
                            string[] typeIndexSplit = type.Split(".");
                            // axis2Bls = typeIndexSplit[0];
                            int typeIndex = int.Parse(typeIndexSplit[1]);
                            SkinnedMeshRenderer smr = b.GetComponent<SkinnedMeshRenderer> ();
                            if (typeIndex >=0 && smr.sharedMesh.blendShapeCount >= typeIndex)
                            {
                                float blendShapeWeight1 = smr.GetBlendShapeWeight(typeIndex);
                                float blendShapeWeight2;
                                if (!fixedX){
                                    blendShapeWeight2 = marginA.x;
                                }else if (!fixedY){
                                    blendShapeWeight2 = marginA.y;
                                }else{
                                    blendShapeWeight2 = marginA.z;
                                }
                                float blendShapeWeight3 = blendShapeWeight1 + blendShapeWeight2;
                                if (blendShapeWeight3 > 100f)
                                {
                                    blendShapeWeight3 = 100f;
                                }else if (blendShapeWeight3 < 0f)
                                {
                                    blendShapeWeight3 = 0f;
                                }
                                smr.SetBlendShapeWeight(typeIndex,blendShapeWeight3);
                                //Debug.Log("GetBlendShapeWeight="+blendShapeWeight1+"; SetBlendShapeWeight="+blendShapeWeight3+".");
                            }else{
                                Debug.Log("The target gameobject has no blendshape matched.");
                            }
                        }else{
                            Debug.Log("The target gameobject has no SkinnedMeshRender component.");
                        }
                    }  
                }          

                returnV3 = marginA;
            }
        }
    }

}
}