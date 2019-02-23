using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingStar : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        transform.Translate(new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-11.0f, 0.0f)));
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0, -speed));

        if (transform.position.y <= -5.5)
        {
            transform.Translate(new Vector2(Random.Range(-8.5f, 8.5f), 12));
        }
	}
}
