using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid_Spawner : MonoBehaviour {

    public GameObject Asteroid_1;
    public GameObject Asteroid_2;
    public GameObject Asteroid_3;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        int score = GameObject.Find("Score").GetComponent<Score>().score;
        int value = Random.Range(0, 1000);
        float Random_X = Random.Range(-8f, 8f);
        Vector2 AsteroidTransform = new Vector2(Random_X, 7);
        
        if (score > 10)
        {
            if (value < (Mathf.Sqrt(score) + 10))
            {
                int asteroid_chance = Random.Range(0, 20);
                if (asteroid_chance <= 11)
                {
                    var Asteroid = Instantiate(Asteroid_1, AsteroidTransform, new Quaternion(0, 0, 0, 0));
                }
                else if (asteroid_chance >= 12 && asteroid_chance <= 16)
                {
                    var Asteroid = Instantiate(Asteroid_2, AsteroidTransform, new Quaternion(0, 0, 0, 0));
                }
                else if (asteroid_chance > 16)
                {
                    var Asteroid = Instantiate(Asteroid_3, AsteroidTransform, new Quaternion(0, 0, 0, 0));
                }
            }
        }
        else {
            if (value < 13)
            {
                int asteroid_chance = Random.Range(0, 20);
                if (asteroid_chance <= 11)
                {
                    var Asteroid = Instantiate(Asteroid_1, AsteroidTransform, new Quaternion(0, 0, 0, 0));
                }
                else if (asteroid_chance >= 12 && asteroid_chance <= 16)
                {
                    var Asteroid = Instantiate(Asteroid_2, AsteroidTransform, new Quaternion(0, 0, 0, 0));
                }
                else if (asteroid_chance > 16)
                {
                    var Asteroid = Instantiate(Asteroid_3, AsteroidTransform, new Quaternion(0, 0, 0, 0));
                }
            }
        }


        //Quit to menu
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            Debug.Log("Loading Menu...");
        }
        //Quit to menu end
    }
}
