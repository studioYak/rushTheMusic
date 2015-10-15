using UnityEngine;
using System.Collections;

public class IceDragonet : Dragonet {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IceDragonet(int attackSpeed, int xpGain, int blocking, int hp, int damage, int movementSpeed, string attackType, string name)
		:base(0, 7, 1, 40, 25, 10, "semiDistance", "anonymous"){

	}
}
