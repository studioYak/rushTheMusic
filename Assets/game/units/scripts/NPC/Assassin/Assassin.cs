﻿using UnityEngine;
using System.Collections;

public class Assassin : NPC {

	// Use this for initialization
	void Start () {
		Debug.Log (this.Name);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.Name);
		//Debug.Log (this.Position[2]);
	}

	public Assassin()
		:base(0, 8, 1, 40, 100, 12, "derriere", "anonymous"){
		
	}
}
