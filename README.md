The Unity's Rotation Constraint Component can be adopted to the circumstance that when Gameobject A is rotating, there is a need of simultaneously rotating another gameobject, B, to a certain extent. However, I cannot by this far how to rotate Gameobject B in a inverted way by using this component, which means a rotation of 30 degrees in A can let B rotate -30 degree instead of the same 30 degree.
Thus, I coded two scripts to realize this demand.

Create two gameobjects such as Cube and Cube(1) in the scene. 
Drag and drop marginTransformGet.cs to Cube, and then it can be seen some options in Inspector window (see the image below).
Assign Game Object B to Cube(1). This means when we rotate Cube, Cube(1) will automatically rotate.
Option Weight defines to what extent Cube(1) will react to Cube's rotation.

![d47aa0e8682a83b4a4fbe9918f3cdcfd_image_ex=660a400e is=65f7cb0e hm=877b867956358974a78cb441782980b4e9469d111b3996aa57bc8856272c16d2](https://github.com/Blatke/Transform-Constraints/assets/125734582/b56d3c14-379b-4a9c-a103-99bf7b2dbe9a)

Click the Play button to run the scene.
Rotate Cube, and you can see Cube(1) is rotating. The Weight is set to 1.0 which means Cube(1) will 100% follow the rotation of Cube. If Weight is 0.4, for instance, and rotation of Cube is 100 degrees, Cube(1) will rotate 100 * 0.4 = 40 degrees.
When Option Inverted is checked, the rotation of Cube(1) will multiply by -1.0 that lets it rotate reversely.
Video: https://github.com/Blatke/Transform-Constraints/assets/125734582/3cc740ea-8d45-42ab-aa85-2cbb05a64346

Change the Option Constraint Type to "r2p". So, Cube(1) will not rotate, instead, it will move its position. How many degrees Cube rotates in XYZ axes, how many units Cube(1) will move in corresponding axes. 
Video: https://github.com/Blatke/Transform-Constraints/assets/125734582/5c2aacda-5550-42c6-9609-5990ce150108

This function might be useful when a forearm rotating and the bones driving the muscles needs to rotate reversely or make a move to let muscles on the arm uplift.

-------
This project was updated. For the new features, please check the Release (https://github.com/Blatke/Transform-Constraints/releases).
