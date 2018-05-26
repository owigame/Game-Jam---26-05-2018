using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class PlayerCharacterController : MonoBehaviour {

	Player _Input;
	Rigidbody rb;
	Animator _anim;
	[SerializeField] float RayD;
	[SerializeField] LayerMask Layer;
	public PlayerNumber playerNumber;

	[SerializeField] float verticalSpeed = 1;
	[SerializeField] float horizontalSpeed = 350;
	[SerializeField] float jumpHeight = 1000;
	bool _grounded = true;

	void Start () {
		Debug.Log ((int) playerNumber);
		rb = GetComponent<Rigidbody> ();
		_anim = GetComponent<Animator> ();
		_Input = ReInput.players.GetPlayer ((int) playerNumber);
	}

	void Update () {
		//Axes
		float _h = _Input.GetAxis ("Horizontal");
		float _v = _Input.GetAxis ("Vertical");
		float _hL = _Input.GetAxis ("Horizontal Look");
		float _vL = _Input.GetAxis ("Vertical Look");

		//Button Input
		bool _Lowkick = _Input.GetButton ("LowKick");
		bool _HighKick = _Input.GetButton ("HighKick");
		bool _Punch = _Input.GetButton ("Punch");
		bool _tongueGrab = _Input.GetButton ("TongueGrab");
		bool _tonguePunch = _Input.GetButton ("TonguePunch");
		bool _jump = _Input.GetButton ("Jump");

		Vector3 MotionVector = Vector3.zero;

		if (_h != 0) {
			Debug.Log ("Horizontal Axis: " + _h);
			MotionVector = new Vector3 (_h * verticalSpeed * Time.deltaTime, MotionVector.y, MotionVector.z);
		}
		if (_v != 0) {
			Debug.Log ("Vertical Axis: " + _v);
			MotionVector = new Vector3 (MotionVector.x, MotionVector.y, _v * horizontalSpeed * Time.deltaTime);
		}
		if (_hL != 0) {
			Debug.Log ("Horizontal Look Axis: " + _hL);
		}
		if (_vL != 0) {
			Debug.Log ("Vertical Look Axis: " + _vL);
		}
		if (_jump == true && _grounded == true) {
			Debug.Log ("Jump Button");
			_anim.SetBool ("Jump", true);
			MotionVector = new Vector3 (MotionVector.x, jumpHeight * Time.deltaTime, MotionVector.z);
			_grounded = false;
		}
		if (_grounded == false) {
			RaycastHit hit;
			Debug.DrawRay (transform.position, -transform.up * RayD,Color.green,1);
			Physics.Raycast (transform.position, -transform.up, out hit, RayD, Layer);
			if (hit.collider != null) {
				_grounded = true;
				_anim.SetBool ("Jump", false);
			}
		}
		if (_Lowkick == true) {
			Debug.Log ("LowKick Button");
			_anim.SetBool ("LowKick", true);
		} else {
			_anim.SetBool ("LowKick", false);
		}
		if (_HighKick == true) {
			Debug.Log ("HighKick Button");
			_anim.SetBool ("HighKick", true);
		} else {
			_anim.SetBool ("HighKick", false);
		}
		if (_Punch == true) {
			Debug.Log ("Punch Button");
			_anim.SetBool ("Punch", true);
		} else {
			_anim.SetBool ("Punch", false);
		}
		if (_tongueGrab == true) {
			Debug.Log ("Tongue Grab Button");
			_anim.SetBool ("TongueGrab", true);
		} else {
			_anim.SetBool ("TongueGrab", false);
		}
		if (_tonguePunch == true) {
			Debug.Log ("Tongue Punch Button");
			_anim.SetBool ("TonguePunch", true);
		} else {
			_anim.SetBool ("TonguePunch", false);
		}

		Move (MotionVector);
	}
	private void Move (Vector3 InputVector) {
		rb.AddForce (InputVector, ForceMode.VelocityChange);
	}
}

[System.Serializable]
public enum PlayerNumber {
	one = 0,
	two = 1,
	three = 2,
	four = 3
}