using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Avatar : MonoBehaviour
{

    public float speed = 7f;
    private float turnspeed = 60f;
    private float verticalInput;
    private float horizontalInput;
    public bool isWalking = false;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

       
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        isWalking = (Mathf.Abs(verticalInput) > 0.0001f);
        animator.SetBool("IsWalking", isWalking);

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnspeed);

        



    }
}
