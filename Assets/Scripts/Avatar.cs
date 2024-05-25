using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Avatar : MonoBehaviour
{

    public float speed = 7f; //Motion speed
    private float turnspeed = 60f; //turning speed
    private float verticalInput; //Vetical keyboard input
    private float horizontalInput; //Horizontal keyboard input
    public bool isWalking = false; //Check if Avatar is moving
    private Animator animator; //Avatar Animator


    void Start()
    {
        //Access Avatar Animator
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        //Transition to next scene when space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }

       
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //initiate animator when Avatar moves
        isWalking = (Mathf.Abs(verticalInput) > 0.0001f);
        animator.SetBool("IsWalking", isWalking);

        //Forwards and Backwards movement
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        //Turning left and Right movement
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnspeed);

        



    }
}
