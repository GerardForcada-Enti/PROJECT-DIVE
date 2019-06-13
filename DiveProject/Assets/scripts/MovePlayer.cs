using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    #region Variables
    [Header("Movement Settings:")]
    public float speed;

    [Header("Physics:")]
    public float fallMultiplier = 2.5f;

    //References
    [Header("References:")]
    private Rigidbody rb;

    //Utilities
    float horizontalInput, verticalInput;
    Vector3 movementDirection, velocity;
    bool playerMoving;
    #endregion

    #region Core
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    #endregion

    #region Movement
    private void Move()
    {
        //Get Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Generate direction vector
        movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        //Is the player moving?
        velocity = new Vector3(horizontalInput, 0, verticalInput);

        if (velocity != Vector3.zero)
            playerMoving = true;
        else
            playerMoving = false;

        //Modify move vector
        if (verticalInput > 0)
            movementDirection = transform.forward;
        else if (verticalInput < 0)
            movementDirection = -transform.forward;

        if (horizontalInput > 0)
            movementDirection = transform.right;
        else if (horizontalInput < 0)
            movementDirection = -transform.right;

        //Add force in direction with speed
        rb.AddForce(movementDirection * speed * Time.deltaTime, ForceMode.Force);
    }
    #endregion

    #region Utilities
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
    #endregion

}
