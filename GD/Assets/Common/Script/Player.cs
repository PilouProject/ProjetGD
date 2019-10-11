using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody playerRb = null;
    public Camera _camera;
    public float maxVelocity = 4.0f;
    public int tireingLevel = 1;
    public int food = 0;
    public Canvas startMenu;
    public Canvas pauseMenu;
    public Canvas gameOverMenu;
    public Slider _foodSlider;
    public bool _triggerHouse;
    private Vector3 offset;
    private float sqrMaxVelocity;
    public Animator animController;
    public AudioSource EatAudio;
    private Vector3 angle = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //On ne fait pas bouger le player tant que l'ecran titre est affiche

        playerRb = GetComponent<Rigidbody>();
        offset = _camera.transform.position - transform.position;
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
        bool isMoving = false;

        if (!startMenu.gameObject.activeSelf && !pauseMenu.gameObject.activeSelf && !gameOverMenu.gameObject.activeSelf)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            transform.position += movement.normalized * maxVelocity * Time.fixedDeltaTime;
            isMoving = !(movement == Vector3.zero);
            if (isMoving)
                transform.eulerAngles = angle = new Vector3(0, Mathf.Atan2(movement.x, movement.z), 0) * Mathf.Rad2Deg;
            else
                transform.eulerAngles = angle;

            _camera.transform.position = transform.position + offset;

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!startMenu.gameObject.activeSelf && !gameOverMenu.gameObject.activeSelf)
                pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
        }
        animController.SetBool("IsMoving", isMoving);

    }

    void OnTriggerEnter(Collider other)
    {
        if (_foodSlider.maxValue > _foodSlider.value && (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("Trash")))
        {
            EatAudio.Stop();
            EatAudio.Play();
            other.gameObject.SetActive(false);
            _foodSlider.value++;
        }

        if (_foodSlider.value >= _foodSlider.maxValue && other.gameObject.tag == "House")
            _triggerHouse = true;

    }
}
