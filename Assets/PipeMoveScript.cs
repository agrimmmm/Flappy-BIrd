using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float speed = 7;
    // private float timer = 0;
    public float deadZone = -40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;
        // if (timer >= 5)
        // {
        //     speed += 1.0f;
        //     timer = 0;
        // }

        // Debug.Log(speed);
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < deadZone)
            Destroy(gameObject);
    }
}
