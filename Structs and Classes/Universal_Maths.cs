using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universal.Maths
{
public struct Universal_Maths
{
	
	public float remainder(float r1, float r2)
	{
		if (r2 != 0)
		{
			return r1 % r2;
		}else{
			return r1;
		}
	}

	public Vector3 remainder(Vector3 r1, float r2)
	{
		if (r2 != 0)
		{
			Vector3 r3 = r1/r2;
			int rx = Mathf.FloorToInt(r3.x);
			int ry = Mathf.FloorToInt(r3.y);
			int rz = Mathf.FloorToInt(r3.z);
			Vector3 r4 = new Vector3(rx,ry,rz);			
			return r1 - r4*r2;
		}else{
			return r1;
		}
	}

}
}
