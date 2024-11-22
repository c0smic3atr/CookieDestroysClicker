using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public int pointValue;
    private GameManager gm;
    
    public GameObject smallerPointer;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(pointValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void SpawnSmaller(int numberToSpawn)
    {
        if(smallerPointer != null)
        {
            for (int i=0; i < numberToSpawn; i++)
            {
                Instantiate(smallerPointer, transform.position, transform.rotation);

            }
            
        }
    }
}
