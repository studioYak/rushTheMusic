using UnityEngine;
using System.Collections;

public class BasicLancer : Lancer {
	
	public GameObject lancePrefab;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public BasicLancer()
		:base(2.0f, 5, 30, 300, 10, "cac", "anonymous"){
		base.weapon = Object.Instantiate(lancePrefab);
	}
}
