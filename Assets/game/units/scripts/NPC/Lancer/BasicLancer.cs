using UnityEngine;
using System.Collections;

public class BasicLancer : Lancer {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public BasicLancer()
		:base(0, 5, 1, 30, 300, 10, "cac", "anonymous"){

	}
}
