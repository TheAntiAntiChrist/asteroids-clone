using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    Rigidbody2D LaserBody;

	// Use this for initialization
	void Start () {
        LaserBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(LaserBody.position.x) > 9.5 || Mathf.Abs(LaserBody.position.y) > 5.5)
        {
            Destroy(LaserBody.gameObject);
        }
	}
}
