using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {


    private float xMoveStep;
    private float zMoveStep;

    public GameObject lineR;

	// Update is called once per frame
	void Update () {
        //transform.RotateAround(new Vector3(0, 1, 0), 10);

        xMoveStep = Input.GetAxis("Horizontal");
        zMoveStep = Input.GetAxis("Vertical");
        //transform.RotateAround(new Vector3(0, 1, 0), 5*Time.deltaTime); //Translate(new Vector3(0f, 1, 0f));
        //lineR.transform.RotateAround(new Vector3(1, 1, 0),0.4f * Time.deltaTime);

	}
}
