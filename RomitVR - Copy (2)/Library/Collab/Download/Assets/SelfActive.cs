using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfActive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0)) {

            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
	}
}
