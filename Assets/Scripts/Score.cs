using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text text;

    public int score;

	void Start () {
        text = GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        text.text = score.ToString();
	}
}
