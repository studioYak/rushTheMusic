using UnityEngine;
using System.Collections;

public class IceLancer : Lancer {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IceLancer()
		:base(0, 7, 1, 40, 400, 10, "cac", "anonymous"){

	}
}
