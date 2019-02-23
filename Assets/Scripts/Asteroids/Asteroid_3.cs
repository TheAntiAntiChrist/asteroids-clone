using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_3 : MonoBehaviour
{
    public GameObject Asteroid_2;

    Rigidbody2D AsteroidRB;

    AudioSource Explosion;

    // Use this for initialization
    void Start()
    {
        AsteroidRB = GetComponent<Rigidbody2D>();
        AsteroidRB.AddRelativeForce(new Vector2(Random.Range(-3f, 3f), -1), ForceMode2D.Impulse);

        Explosion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroys game object when it goes OOB
        if (Mathf.Abs(transform.position.x) > 12 || Mathf.Abs(transform.position.y) > 8)
        {
            Destroy(AsteroidRB.gameObject);
        }
        //End OOB

        //constant transform
        AsteroidRB.rotation += 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Spaceship")
        {
            GameObject.Find("GameOver").GetComponent<UnityEngine.UI.Text>().text = "Game Over";
            GameObject.Find("PressEsc").GetComponent<UnityEngine.UI.Text>().text = "Press escape to continue...";
            Destroy(collision.gameObject);
            Explosion.pitch = Random.Range(0.8f, 1.2f);
            Explosion.Play();
        }
        if (collision.collider.name == "Laser(Clone)")
        {
            Destroy(AsteroidRB.gameObject);
            Destroy(collision.gameObject);
            GameObject.Find("Score").GetComponent<Score>().score += 1;
            for (int i = 0; i < 2; i++)
            {
                var Asteroid = Instantiate(Asteroid_2, AsteroidRB.position, new Quaternion(0, 0, 0, 0));
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LaserBeam(Clone)")
        {
            Destroy(AsteroidRB.gameObject);
            GameObject.Find("Score").GetComponent<Score>().score += 1;
        }
    }
}
