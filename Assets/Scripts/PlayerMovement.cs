using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float jumpForce = 6.0f;
    float movementSpeed = 5.0f;
    Rigidbody playerBody;
    Animator playerAnimator;
    float horizontalMovement = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (horizontalMovement > 0)
        {
            playerBody.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (horizontalMovement < 0)
        {
            playerBody.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if(Mathf.Abs(horizontalMovement) > 0.1f)
        {
            playerAnimator.SetBool("isIdle", false);
            playerAnimator.SetBool("isRunning", true);

        }else
        {
            playerAnimator.SetBool("isIdle", true);
            playerAnimator.SetBool("isRunning", false);
        }
        playerBody.velocity = new Vector3(horizontalMovement * movementSpeed, playerBody.velocity.y, 0f);
        if(Input.GetKeyDown(KeyCode.Space)){
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

            Debug.Log("The Spacebar has been pressed.");
        }
        
    }
}
