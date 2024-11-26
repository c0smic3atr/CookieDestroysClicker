using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gm;
    public float horizontalRange;
    public float verticalRange;

    public GameObject player;
    public GameObject pointer;

    public int pointersToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        horizontalRange = gm.horizontalLimit;
        verticalRange = gm.verticalLimit;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            SpawnWave(pointersToSpawn);
        }
    }

    public Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        //float randomZ = Random.Range(-verticalRange, verticalRange);
        Vector3 randomPos = new Vector3(randomX, 0, 0);


        while((randomPos - player.transform.position).magnitude < gm.safetyRadius)
        {
            randomX = Random.Range(-horizontalRange, horizontalRange);
            //randomZ = Random.Range(-verticalRange, verticalRange);
            randomPos = new Vector3(randomX, 0, 0);
        }
        return randomPos;
    }

    public void SpawnWave(int pointers)
    {
        for(int i = 0; i < pointers; i++)
        {
            Instantiate(pointer, GenerateRandomPosition(), transform.rotation);
        }
    }
}
