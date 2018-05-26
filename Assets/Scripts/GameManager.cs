using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class GameManager : MonoBehaviour {

	Player _Input;

	void Start () {
		_Input = ReInput.players.GetPlayer (0);
	}

	void Update () {
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

		if (_h != 0) {
			Debug.Log ("Horizontal Axis: " + _h);
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
	}
}