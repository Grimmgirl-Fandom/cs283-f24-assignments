using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidFollowCamera : MonoBehaviour
{

    public Transform Target;
    public float hDist;
    public float vDist;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       Vector3 tPos = Target.position;
        Vector3 tUp = Target.up;
        Vector3 tForward = Target.forward;
        // tPos, tUp, tForward = Position, up, and forward vector of target
            
        // hDist = horizontal follow distance
        // vDist = vertical follow distance

        // Camera position is offset from the target position
        Vector3 eye = tPos - tForward * hDist + tUp * vDist;

        // The direction the camera should point is from the target to the camera position
        Vector3 cameraForward = tPos - eye;

        // Set the camera's position and rotation with the new values
        // This code assumes that this code runs in a script attached to the camera
        transform.position = eye;
        transform.rotation = Quaternion.LookRotation(cameraForward);

    }
}
