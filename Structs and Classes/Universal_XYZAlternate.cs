// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.1.0 on March 18, 2024. 
// To let the values of XYZ axes appear in different places in the vector.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universal.CaseStringNormalize;

namespace Universal.XYZAlternate
{
public struct Universal_XYZAlternate
{
    public Vector3 d(Vector3 v, string axisStandard)
    {
        Universal_CaseStringNormalize csnl;
        axisStandard = csnl.d(axisStandard, true, true, true, "", "");

        if (axisStandard != null && axisStandard != "")
        {
            float x = v.x, y = v.y, z = v.z;
            switch (axisStandard)
            {
                case "x=y":
                case "y=z":
                case "z=x":
                    v = new Vector3(y, z, x);
                    break;
                case "x=z":
                case "y=x":
                case "z=y":
                    v = new Vector3(z, x, y);
                    break;
                case "x=x":
                case "y=y":
                case "z=z":
                default:
                    break;
            }
        }

        return v;
    }
}
}