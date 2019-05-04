using UnityEngine;
using System.Collections;

public class RotateCameraAroundObject : MonoBehaviour {

    public Transform target;        //What to rotate around
    public float distance = 5.0f;   //How far away to orbit
    public float xSpeed = 50.0f;   //X sensitivity
    public float ySpeed = 50.0f;    //Y sensitivity

    private float x = 0.0f;         //Angle of the y rotation?
    private float y = 0.0f;         //Angle of the x rotation?

	// Use this for initialization
	void Start () {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
	}

    void LateUpdate()
    { 
        if (target)
        {
            //Change the angles by the mouse movement            
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            //Rotate the camera to those angles 
            var rotation = Quaternion.Euler(y, x, 0);
            transform.rotation = rotation;

            //Move the camera to look at the target
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
            transform.position = position;
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
