using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class PlayerCharacterController : MonoBehaviour {

	Player _Input;
	Rigidbody rb;
	Animator _anim;
	[SerializeField] float verticalSpeed = 1;

	void Start () {
		_Input = ReInput.players.GetPlayer (0);
		rb = GetComponent<Rigidbody> ();
		_anim = GetComponent<Animator> ();
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

		if (_h != 0) {
			Debug.Log ("Horizontal Axis: " + _h);
			rb.AddForce (new Vector3 (_h * verticalSpeed * Time.deltaTime, 0, 0), ForceMode.Force);
		}
		if (_v != 0) {
			Debug.Log ("Vertical Axis: " + _v);
		}
		if (_hL != 0) {
			Debug.Log ("Horizontal Look Axis: " + _hL);
		}
		if (_vL != 0) {
			Debug.Log ("Vertical Look Axis: " + _vL);
		}
		if (_Lowkick == true) {
			Debug.Log ("LowKick Button");
			_anim.SetBool ("LowKick", true);
		} 
		else {
			_anim.SetBool ("LowKick", false);
		}
		if (_HighKick == true) {
			Debug.Log ("HighKick Button");
			_anim.SetBool ("HighKick", true);
		}
		else {
			_anim.SetBool ("HighKick", false);
		}
		if (_Punch == true) {
			Debug.Log ("Punch Button");
			_anim.SetBool ("Punch", true);
		}
			else {
			_anim.SetBool ("Punch", false);
		}
		if (_tongueGrab == true) {
			Debug.Log ("Tongue Grab Button");
			_anim.SetBool ("TongueGrab", true);
		}
		else {
			_anim.SetBool ("TongueGrab", false);
		}
		if (_tonguePunch == true) {
			Debug.Log ("Tongue Punch Button");
			_anim.SetBool ("TonguePunch", true);
		}
			else {
			_anim.SetBool ("TonguePunch", false);
		}
	}
}