using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacterController : MonoBehaviour {

	Player _Input;
	Rigidbody rb;
	public PlayerNumber playerNumber;
	[SerializeField]float verticalSpeed = 700;
	[SerializeField]float horizontalSpeed = 350;

    void Start () 
	{

		Debug.Log((int) playerNumber);
		_Input = ReInput.players.GetPlayer ((int) playerNumber);
		rb = GetComponent <Rigidbody>();
	}

	void Update ()
	{
		//Axes
		float _h = _Input.GetAxis ("Horizontal");
		float _v = _Input.GetAxis ("Vertical");
		float _hL = _Input.GetAxis ("Horizontal Look");
		float _vL = _Input.GetAxis ("Vertical Look");

		//Button Input
		bool _kick = _Input.GetButton ("Kick");
		bool _chop = _Input.GetButton ("Chop");
		bool _tongueGrab = _Input.GetButton ("TongueGrab");
		bool _tonguePunch = _Input.GetButton ("TonguePunch");

		Vector3 MotionVector = Vector3.zero;

		if (_h != 0) {
			Debug.Log ("Horizontal Axis: " + _h);
			MotionVector = new Vector3(_h * verticalSpeed * Time.deltaTime, MotionVector.y,MotionVector.z);
		}
		if (_v != 0) {
			Debug.Log ("Vertical Axis: " + _v);
			MotionVector = new Vector3(MotionVector.x, MotionVector.y, _v * horizontalSpeed * Time.deltaTime);
		}
		if (_hL != 0) {
			Debug.Log ("Horizontal Look Axis: " + _hL);
		}
		if (_vL != 0) {
			Debug.Log ("Vertical Look Axis: " + _vL);
		}
		if (_kick) {
			Debug.Log ("Kick Button");
		}
		if (_chop) {
			Debug.Log ("Chop Button");
		}
		if (_tongueGrab) {
			Debug.Log ("Tongue Grab Button");
		}
		if (_tonguePunch) {
			Debug.Log ("Tongue Punch Button");
		}

		Move(MotionVector);
	}
	private void Move(Vector3 InputVector){
		rb.AddForce(InputVector,ForceMode.VelocityChange);
	}
}


[System.Serializable]
public enum PlayerNumber{
	one = 0,
	two = 1,
	three = 2,
	four = 3
}