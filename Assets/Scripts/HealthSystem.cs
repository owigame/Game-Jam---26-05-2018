using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
public float health = 100;
	// Use this for initialization
	public void decreaseHealth (float amount){
		health -= amount;
	}
	public void increaseHealth (float amount){
	health += amount;
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
