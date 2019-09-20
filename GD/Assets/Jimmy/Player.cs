using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody playerRb = null;
    public Camera camera;

    public float movementSpeed = 4.0f;
    public int tireingLevel = 0;
    public int food = 0;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        offset = camera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = transform.position + offset;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.velocity = new Vector3(1, 0, 0) * movementSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.velocity = new Vector3(-1, 0, 0) * movementSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRb.velocity = new Vector3(0, 0, 1) * movementSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRb.velocity = new Vector3(0, 0, -1) * movementSpeed;
        }
    }


}
