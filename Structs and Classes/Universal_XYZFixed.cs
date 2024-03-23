// Coded by Bl@ke. http://www.blatke.cc/
// Version 0.1.0 on March 18, 2024. 
// To let some or all of the values of a vector in XYZ axes be ZERO so that if this is a vector indicating the margins in a transform change, one or more axes will be fixed and without changing its values.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universal.XYZFixed
{
public struct Universal_XYZFixed
{
    public Vector3 d(Vector3 v, bool isX, bool isY, bool isZ)
    {
        float x = v.x, y = v.y, z = v.z;
        if (isX)
        {
            x = 0f;
        }
        if (isY)
        {
            y = 0f;
        }
        if (isZ)
        {
            z = 0f;
        }
        v = new Vector3(x, y, z);
        return v;
    }
}
}