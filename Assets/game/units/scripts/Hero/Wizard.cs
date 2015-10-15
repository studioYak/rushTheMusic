using UnityEngine;
using System.Collections;

public class Wizard : Hero {
	
	
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Wizard(int xpQuantity, string handAttack, int powerQuantity, int hpRefresh, int powerRefresh, bool defending, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(xpQuantity, handAttack, powerQuantity, hpRefresh, powerRefresh, defending, hp, damage, movementSpeed, attackType, name){
		
	}
	
}