using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ExcavatorMove : MonoBehaviour
{
    // movement variables
    public float movementSpeed = 2.0f;
    public float rotationSpeed = 50.0f;
    public bool isDigging;

    // create a gameobject reference for the excavator
    public GameObject excavator;
    // create a rigidbody reference for the excavator
    private Rigidbody excavatorRigidbody;
    // reference to the Animator component
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // assign the rigidbody to a variable and tell it that gravity is being used
        excavatorRigidbody = GetComponent<Rigidbody>();
        excavatorRigidbody.useGravity = true;

        // get the Animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * Time.deltaTime * movementSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(transform.forward * Time.deltaTime * -movementSpeed, Space.World);
        }

        // Check for spacebar press (not hold)
        if (Input.GetKeyDown(KeyCode.Space) && !isDigging)
        {
            StartCoroutine(PlayDigAnimation());
        }

        if (Input.GetKey(KeyCode.R))
        {
            Reset();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private IEnumerator PlayDigAnimation()
    {
        isDigging = true;

        // Trigger the animation
        animator.Play("bucketDig");

        // Wait for the animation to complete
        // You'll need to adjust this time to match your animation length
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        isDigging = false;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}