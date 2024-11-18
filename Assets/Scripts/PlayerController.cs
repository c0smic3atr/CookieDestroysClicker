using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float cookieTurnSpeed;
    public float cookieMoveSpeed;
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody cookieRb;

    public GameObject bullet;
    public GameObject bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        cookieRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * cookieTurnSpeed * horizontalInput * Time.deltaTime);

        //Shooting
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        //Moving
        verticalInput = Input.GetAxis("Vertical");
        cookieRb.AddRelativeForce(Vector3.forward * cookieMoveSpeed * verticalInput);
    }
}
