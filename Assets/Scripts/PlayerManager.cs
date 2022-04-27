using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rb;
    GameManager gameManager;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Asteroid>() && PowerUpManager.Instance.state != 
                                                        PowerUpManager.PowerUpState.SHIELD) {

            CinemachineShake.Instance.ShakeCamera(5f, 1);

            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            transform.rotation = Quaternion.identity;
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.ResetMoveInput();

            gameObject.SetActive(false);
            gameManager.PlayerDied();
            PowerUpManager.Instance.ResetPowerUps();
            
        }
    }

}