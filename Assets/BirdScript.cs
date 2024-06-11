using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public AudioSource gameAudio;
    public LogicScript logic;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();  
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        gameAudio = GetComponent<AudioSource>();
        isAlive = true;

        logic.GetHighScore();
        gameAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isAlive)
            myRigidbody.velocity = Vector2.up * flapStrength;
        if(Input.touchCount > 0 && isAlive)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
                myRigidbody.velocity = Vector2.up * flapStrength;
        }
        outOfBounds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.Game_Over();
        isAlive = false;
        gameAudio.Stop();
    }

    private void outOfBounds()
    {
        if (transform.position.y < -11 || transform.position.y > 11)
        {
            logic.Game_Over();
            isAlive = false;
            gameAudio.Stop();
        }
    }
}
