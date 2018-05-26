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
			MotionVector = new Vector3 (_h * verticalSpeed * Time.deltaTime, MotionVector.y, MotionVector.z);
            _anim.SetFloat("speedH",_h);

        }
        if (_v != 0) {
			MotionVector = new Vector3 (MotionVector.x, MotionVector.y, _v * horizontalSpeed * Time.deltaTime);
            _anim.SetFloat("speedV", _v);

        }
        if (_jump == true && _grounded == true) {
			_anim.SetBool ("Jump", true);
			MotionVector = new Vector3 (MotionVector.x, jumpHeight * Time.deltaTime, MotionVector.z);
			_grounded = false;
		}
		if (_grounded == false) {
			RaycastHit hit;
			Physics.Raycast (transform.position, -transform.up, out hit, RayD, Layer);
			if (hit.collider != null) {
				_grounded = true;
				_anim.SetBool ("Jump", false);
			}
		}
		if (_Lowkick == true) {
			_anim.SetTrigger ("LowKick");
		}
		if (_HighKick == true) {
			_anim.SetTrigger ("HighKick");
		}
		if (_Punch == true) {
			_anim.SetTrigger ("Punch");
		} 
		if (_tongueGrab == true) {
			_anim.SetTrigger ("TongueGrab");
		} 
		if (_tonguePunch == true) {
			_anim.SetTrigger ("TonguePunch");
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