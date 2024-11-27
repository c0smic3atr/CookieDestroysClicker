using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public int pointValue;
    private GameManager gm;
    public Rigidbody pointerRb;
    
    public GameObject smallerPointer;
    public int smallPointerToSpawn;

    public float forceRange;
    public float torqueRange;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pointerRb = GetComponent<Rigidbody>();

        AddRandomForce();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(pointValue);
            Destroy(collision.gameObject);
            SpawnSmaller(smallPointerToSpawn);
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            gm.PlayerDie();
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

    public void AddRandomForce()
    {
        float randomForceX = Random.Range(-forceRange, forceRange);
        float randomForceZ = Random.Range(-forceRange, forceRange);
        Vector3 randomForce = new Vector3(randomForceX, 0, randomForceZ);

        pointerRb.AddForce(randomForce, ForceMode.Impulse);
    }

    public void AddRandomTorque()
    {
        float randomTorque = Random.Range(-torqueRange, torqueRange);
        pointerRb.AddTorque(Vector3.back * randomTorque, ForceMode.Impulse);
    }
}
