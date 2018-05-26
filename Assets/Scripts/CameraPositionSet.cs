using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionSet : MonoBehaviour {

    bool SetCameraInPositios;
    public Transform CameraPosition;
    public Transform CameraMoveToPosition;

    private float CurrentPositionInTime;

	void Update ()
    {
        if(SetCameraInPositios == true)
        {
            CurrentPositionInTime += 0.5f * Time.deltaTime;
            CameraPosition.transform.position = Vector3.Lerp(CameraPosition.position, CameraMoveToPosition.position, CurrentPositionInTime);
        }

        if(CameraPosition.position == CameraMoveToPosition.position)
        {
            SetCameraInPositios = false;
            CurrentPositionInTime = 0;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SetCameraInPositios = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SetCameraInPositios = false;
        }
    }

}
