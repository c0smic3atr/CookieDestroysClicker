using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float cookieTurnSpeed;
    public float cookieMoveSpeed;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * cookieTurnSpeed * horizontalInput * Time.deltaTime);

        //Moving
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * cookieMoveSpeed * verticalInput * Time.deltaTime);
    }
}
