using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    float Y_Velocity;

    public float speed;
    public float rotation_speed;

    Rigidbody2D PlayerRB;

    public GameObject LaserPrefab;
    public GameObject LaserTransform;

    public GameObject LaserBeamPrefab;
    public GameObject LaserBeamTransform;

    public GameObject self;

    public AudioClip LaserSound;
    public AudioClip LaserBeamSound;
    public AudioClip ThrusterSound;

    AudioSource Audio;

    float TimeLeft;
    float Timer;

	// Use this for initialization
	void Start () {
        PlayerRB = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W))
        {
            Y_Velocity = speed;
            //Audio.PlayOneShot(ThrusterSound, 1f);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            Y_Velocity = -speed;
            //Audio.PlayOneShot(ThrusterSound, 1f);
        }
        else if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
        {
            if (Y_Velocity != 0)
            {
                Y_Velocity = 0;
                
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerRB.rotation += rotation_speed;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerRB.rotation -= rotation_speed;
            
        }
        //if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        //{
        //    
        //}

        PlayerRB.AddRelativeForce(new Vector2(0, Y_Velocity));
        PlayerRB.angularVelocity = 0;
        //Movement end

        //Player world loop
        if (PlayerRB.position.x < -9.5)
        {
            PlayerRB.position = new Vector2(9.5f, PlayerRB.position.y);
        }
        if (PlayerRB.position.x > 9.5)
        {
            PlayerRB.position = new Vector2(-9.5f, PlayerRB.position.y);
        }
        if (PlayerRB.position.y < -5.5)
        {
            PlayerRB.position = new Vector2(PlayerRB.position.x, 5.5f);
        }
        if (PlayerRB.position.y > 5.5)
        {
            PlayerRB.position = new Vector2(PlayerRB.position.x, -5.5f);
        }
        //Player world loop end
    }

    void Update()
    {
        //Laser shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TimeLeft = 1f;
            Timer = 0f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //TimeLeft -= Time.deltaTime;
            Timer += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            if (Timer > 0.5)
            {
                Transform PlayerTransform = GetComponent<Transform>();
                var LaserBeam = Instantiate(LaserBeamPrefab, LaserBeamTransform.transform.position, LaserBeamTransform.transform.rotation);
                LaserBeam.transform.SetParent(PlayerTransform);
                Audio.PlayOneShot(LaserBeamSound, 0.7f);
            }
            else
            {
                Audio.pitch = Random.Range(0.8f, 1.2f);
                Audio.PlayOneShot(LaserSound, 0.7f);
                var Laser = Instantiate(LaserPrefab, LaserTransform.transform.position, LaserTransform.transform.rotation);
                Rigidbody2D LaserBody = Laser.GetComponent<Rigidbody2D>();
                LaserBody.AddRelativeForce(new Vector2(0, 15), ForceMode2D.Impulse);
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    LaserSound.pitch = Random.Range(0.8f, 1.2f);
        //    LaserSound.Play();
        //    var Laser = Instantiate(LaserPrefab, LaserTransform.transform.position, LaserTransform.transform.rotation);
        //    Rigidbody2D LaserBody = Laser.GetComponent<Rigidbody2D>();
        //    LaserBody.AddRelativeForce(new Vector2(0, 15), ForceMode2D.Impulse);
        //}
        //Laser shoot end   

    }
}
