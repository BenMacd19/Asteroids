using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rb;

    public float moveSpeed;
    public float rotateSpeed;
    public float maxVelocity;

    float defMoveSpeed;
    float defMaxVelocity;

    GameObject leftEngine;
    GameObject rightEngine;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        leftEngine = GameObject.Find("Left Engine");
        rightEngine = GameObject.Find("Right Engine");

        defMoveSpeed = moveSpeed;
        defMaxVelocity = maxVelocity;
    }

    void Update()
    {
        SwitchEngine();
    }

    void FixedUpdate() {
        MovePlayer();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    public void ResetMoveInput() {
        moveInput = new Vector2(0,0);
    }

    // Moves the player using the moveInput variable
    void MovePlayer() {

        // If the player is not at max speed and they are pushing forward
        // then a force will be added to the player
        if (rb.velocity.magnitude < maxVelocity && moveInput.y > 0) {
            rb.AddForce((moveInput.y * moveSpeed) * transform.up);
        }
        
        // rotates the player left or right depending on if they input left or right
        rb.AddTorque(-moveInput.x * rotateSpeed);
        
    }

    void SwitchEngine() {

        // Forward
        if (moveInput.y > 0) {
            leftEngine.transform.localScale = new Vector3(0.85f, 1 , 1);
            rightEngine.transform.localScale = new Vector3(0.85f, 1 , 1);
        }

        // Left
        if (moveInput.x < 0) {
            leftEngine.transform.localScale = new Vector3(0.25f, 1 , 1);
        }

        // Right
        if (moveInput.x > 0) {
            rightEngine.transform.localScale = new Vector3(0.25f, 1 , 1);
        }

        // Idle
        if (moveInput.x == 0 && moveInput.y == 0) {
            leftEngine.transform.localScale = new Vector3(0.5f, 1 , 1);
            rightEngine.transform.localScale = new Vector3(0.5f, 1 , 1);
        }

    }

    public float GetDefMoveSpeed() {
        return defMoveSpeed;
    }

    public float GetDefMaxVelocity() {
        return defMaxVelocity;
    }

}