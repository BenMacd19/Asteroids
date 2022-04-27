using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gunner : MonoBehaviour
{

    Vector2 aimPos;
    Camera cam;

    private void Awake() {
        if (MainMenu.player2 == false) {
            gameObject.SetActive(false);
        }
    }

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        LookDirection();
    }

    // Points the player to the position of the mouse
    void LookDirection() {
        aimPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 lookDir = aimPos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
