using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    BoxCollider2D LaserBeamCollider;

    float timer;

    bool shrink;

    public bool CameraShake;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Camera").GetComponent<CameraShake>().IsCameraShake = true;
        LaserBeamCollider = GetComponent<BoxCollider2D>();
        timer = 0;
        shrink = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.65)
        {
            shrink = true;
        }
        if (!shrink)
        {
            transform.localScale += new Vector3(0.04f, 0, 0);
        }
        else
        {
            transform.localScale += new Vector3(-2f, 0, 0);
        }
        if (transform.localScale.x <= 0)
        {
            GameObject.Find("Camera").GetComponent<CameraShake>().IsCameraShake = false;
            Destroy(LaserBeamCollider.gameObject);
        }
    }
}
