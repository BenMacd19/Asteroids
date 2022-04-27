using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public static PowerUpManager Instance { get; private set; }

    public Transform p;

    PlayerManager player;
    PlayerMovement playerMovement;
    Shoot playerShoot;

    SpriteRenderer shield;
    GameObject middleEngine;

    public enum PowerUpState { NONE, BOOST, SHIELD, TRIPLESHOOT }
    public PowerUpState state;

    void Awake() {
        Instance = this;
    }

    private void Start() {
        player = p.GetComponent<PlayerManager>();
        playerMovement = p.GetComponent<PlayerMovement>();
        playerShoot = p.GetComponent<Shoot>();
        shield = p.GetComponent<SpriteRenderer>();
        middleEngine = GameObject.Find("Middle Engine");

        state = PowerUpState.NONE;
    }

    public IEnumerator AddBoost(float boostSpeed, float duration) {
        state = PowerUpState.BOOST;
        middleEngine.transform.localScale = new Vector3(1, 1, 1);       
        playerMovement.moveSpeed += boostSpeed;
        playerMovement.maxVelocity += boostSpeed;

        yield return new WaitForSeconds(duration);

        ResetBoost();
    }

    public void ResetBoost() {
        playerMovement.moveSpeed = playerMovement.GetDefMoveSpeed();
        playerMovement.maxVelocity = playerMovement.GetDefMaxVelocity();

        middleEngine.transform.localScale = new Vector3(0, 0, 0);
        state = PowerUpState.NONE;
    }

    public IEnumerator AddShield(float duration) {
        state = PowerUpState.SHIELD;
        shield.color = Color.blue;

        yield return new WaitForSeconds(duration);

        ResetShield();
    }

    public void ResetShield() {
        shield.color = Color.white;
        state = PowerUpState.NONE;
    }

    public IEnumerator AddTripleShoot(float duration) {
        state = PowerUpState.TRIPLESHOOT;
        playerShoot.muzzleFlash = playerShoot.tripleShootMuzzleFlash;
        playerShoot.SetTripleShoot(true);

        yield return new WaitForSeconds(duration);

        ResetTripleShoot();
    }

    public void ResetTripleShoot() {
        playerShoot.muzzleFlash = playerShoot.GetDefMuzzleFlash();
        playerShoot.SetTripleShoot(false);
        state = PowerUpState.NONE;
    }

    public void ResetPowerUps() {
        ResetBoost();
        ResetShield();
        ResetTripleShoot();
    }

}
