using UnityEngine;
using System.Collections;

public class Warrior : Hero {
	

	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.magenta;

	}
	
	// Update is called once per frame
	void Update () {

	}

	public Warrior()
		:base(0,"epee",100, 5, 0, false, 500,  new int [] {10, 0, 12}, 12, 3, "CAC", "Bob"){

	}
	
}

