using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public bool IsCameraShake;
    float TimeSinceLastShake;
    // Use this for initialization
    void Start()
    {
        TimeSinceLastShake = 0;
    }

	// Update is called once per frame
	void Update () {
        if (IsCameraShake)
        {
            TimeSinceLastShake += Time.deltaTime;
            if (TimeSinceLastShake > 0.01)
            {
                float RanX = Random.Range(-0.1f, 0.1f);
                float RanY = Random.Range(-0.1f, 0.1f);

                transform.position = new Vector3(RanX, RanY, -10);
                TimeSinceLastShake = 0;
            }
        }
        else
        {
            transform.position = new Vector3(0, 0, -10);
        }
    }
}
