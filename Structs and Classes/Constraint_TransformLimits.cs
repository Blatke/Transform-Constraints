// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.1.0 on March 23, 2024. 
// This is for checking whether or not a designated vector in a transform change does lie in a certain range of values.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universal.DegreeNormalize;

namespace Constraint.TransformLimits
{
public struct Constraint_TransformLimits
{
    public Vector3 m(string typeStr, Vector3 marginV, Vector3 currentV, Vector3 rangeA, Vector3 rangeB, bool isNormalized)
    {
        //if (!isNormalized)
        //{
            Universal_DegreeNormalize dnl;
            marginV = dnl.d(marginV);
            currentV = dnl.d(currentV);
            // Vector3 a = dnl.d(marginV + currentV - rangeA);
            // rangeA = dnl.d(rangeA);
            // rangeB = dnl.d(rangeB);
        //}

        Vector3 m = new Vector3(0f,0f,0f);

        typeStr = typeStr.ToLower();
        switch (typeStr)
        {
            case "inrange":
            case "inscope":     // The marginal vector should be in the limited range.
                if (vCompare(marginV, rangeA, ">=") && vCompare(marginV, rangeB, "<="))
                {
                    m = marginV;                    
                }
                break;
            case "outrange":
            case "outscope":    // The marginal vector should be out of the limited range.
                if (vCompare(marginV, rangeA, "<=") || vCompare(marginV, rangeB, ">="))
                {
                    m = marginV;
                }
                break;
            
            case "inrangetotal":
            case "inscopetotal":    // The total vector after calculation should be in the limited range. 
                if (vCompare(marginV + currentV, rangeA, ">=") && vCompare(marginV + currentV, rangeB, "<="))
                {
                    m = marginV;
                    // Debug.Log(a);
                }
                break;

            /* case "outrangetotal":
            case "outscopetotal":   // The total vector after calculation should be out of the limited range.
                if (vCompare(marginV + currentV, rangeA, "<=||") || vCompare(marginV + currentV, rangeB, ">=||"))
                {
                    m = marginV;
                }
                break; */
            
            /* case "inrangetotalmargin":
            case "inscopetotalmargin":    // The total vector after calculation should be in the limited range. 
                if (vCompare(marginV + currentV, rangeA, ">=") && vCompare(marginV + currentV, rangeB, "<="))
                {
                    m = marginV;
                }
                break; */

            /* case "outrangetotalmargin":
            case "outscopetotalmargin":   // The total vector after calculation should be out of the limited range.
                if (vCompare(marginV + currentV, rangeA, "<=") || vCompare(marginV + currentV, rangeB, ">="))
                {
                    m = marginV;
                }
                break; */

            case "inrangecurrent":  // When the marginal degrees let any value in the current vector be out of the range, set the margin to 0.
                if (vCompare(marginV + currentV, rangeA, "<=||") || vCompare(marginV + currentV, rangeB, ">=||"))
                {
                    m = new Vector3(0f,0f,0f);                    
                }
                break;

            default:
                break;
        }

        return m;
    }

    private bool vCompare(Vector3 a, Vector3 b, string sign)
    {
        bool v = false;
        float xa = a.x, ya = a.y, za = a.z;
        float xb = b.x, yb = b.y, zb = b.z;

        switch (sign)
        {
            case ">=":
                if (xa >= xb && ya >= yb && za >= zb)
                {
                    v = true;
                }
                break;
            case ">":
                if (xa > xb && ya > yb && za > zb)
                {
                    v = true;
                }
                break;
            case "<=":
                if (xa <= xb && ya <= yb && za <= zb)
                {
                    v = true;
                }
                break;
            case "<":
                if (xa < xb && ya < yb && za < zb)
                {
                    v = true;
                }
                break;
            
            case ">=||":
                if (xa >= xb || ya >= yb || za >= zb)
                {
                    v = true;
                }
                break;
            case ">||":
                if (xa > xb || ya > yb || za > zb)
                {
                    v = true;
                }
                break;
            case "<=||":
                if (xa <= xb || ya <= yb || za <= zb)
                {
                    v = true;
                }
                break;
            case "<||":
                if (xa < xb || ya < yb || za < zb)
                {
                    v = true;
                }
                break;
            
            default:
                break;                
        }

        return v;
    }
}
}