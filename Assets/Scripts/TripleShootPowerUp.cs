using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShootPowerUp : MonoBehaviour
{

    [SerializeField] int duration;

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && PowerUpManager.Instance.state == 
                PowerUpManager.PowerUpState.NONE) {
            AchievementManager.Instance.tripleShoot = true;
            Pickup();
        }
    }

    void Pickup() {

        PowerUpManager.Instance.StartCoroutine(PowerUpManager.Instance.AddTripleShoot(duration));
        
        // Disable power up
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject);
    }



}
