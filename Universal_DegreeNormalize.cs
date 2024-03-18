using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Universal.Maths;

namespace Universal.DegreeNormalize
{
public struct Universal_DegreeNormalize //Convert the abnormal degree of rotation such as 358 or 359 to the normal degree such like -2 or -1.
{
    public Vector3 d (Vector3 v3)   
    {
        Universal_Maths maths;
        Vector3 v3a = maths.remainder(v3,360f);
        float x = v3a.x;
        float y = v3a.y;
        float z = v3a.z;
        x = degreeNL_b(x);
        y = degreeNL_b(y);
        z = degreeNL_b(z);
        v3a = new Vector3(x,y,z);
        return v3a;
    }

    private float degreeNL_b (float a)
    {
        int sign = getSign (a);
        a = Mathf.Abs(a);

        //if (a > 180f && a <= 270f)
        //{
           // a -= 180f;
        //}else 
        if (a > 270f && a <= 360f)
        {
            a -= 360f;
        }

        return (a * sign);
    }

    private int getSign (float a)
    {
        if (a < 0){
            return -1;
        }else{
            return 1;
        }
    }
}
}