The functions that need to be added in the future:

1. Option of limit on the degree of rotation of the target gameobject. (Or maybe create a new component script to realize this.)
   
2. Option of degree range of the current gameobject's rotation to which the target gameobject will conduct or not conduct reaction. For instance, if this range is set to [30,35] with the Checkbox Excluded being checked, and when the current gameobject has rotated in an Update by 33 degrees, the target gameobject does NOT react. But when the rotation is by 36 degrees that is out of the range, the target DOES react.
  
3. Operation on the target's material (relative to the shader) properties. For instance, input "Normal" in a particualr textbox will finally allow the current gameobject's rotation to affect the parameter of the target's normal map. If a boot is rotating and its wrinkles it might appear on its surface are realized by a normal map, this function could help. 
