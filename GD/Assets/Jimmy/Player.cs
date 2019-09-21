using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody playerRb = null;
    public Camera camera;
    public float maxVelocity = 4.0f;
    public int tireingLevel = 0;
    public int food = 0;
    public Button startButton;

    private Vector3 offset;

    private float sqrMaxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //On ne fait pas bouger le player tant que l'ecran titre est affiche

        playerRb = GetComponent<Rigidbody>();
        offset = camera.transform.position - transform.position;
        SetMaxVelocity(maxVelocity);
    }

    void SetMaxVelocity(float maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!startButton.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.RightArrow))
                playerRb.velocity = playerRb.velocity + new Vector3(1, 0, 0) * maxVelocity;
            if (Input.GetKey(KeyCode.LeftArrow))
                playerRb.velocity = playerRb.velocity + new Vector3(-1, 0, 0) * maxVelocity;
            if (Input.GetKey(KeyCode.UpArrow))
                playerRb.velocity = playerRb.velocity + new Vector3(0, 0, 1) * maxVelocity;
            if (Input.GetKey(KeyCode.DownArrow))
                playerRb.velocity = playerRb.velocity + new Vector3(0, 0, -1) * maxVelocity;
            camera.transform.position = transform.position + offset;
        }

        if (playerRb.velocity.sqrMagnitude > sqrMaxVelocity)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxVelocity;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

        }
    }
}
