using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 5;
    private float timer = 0;
    private int count = 0;
    public float heightOffset = 5;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnRate > 2.5f && count % 3 == 0 && count != 0)
        {
            spawnRate -= 0.5f;
            count = 0;
        }

        if (timer >= spawnRate)
        {
            spawnPipe();
            timer = 0;
            count++;
        }
        else
            timer += Time.deltaTime;
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
