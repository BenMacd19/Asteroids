using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{

    [SerializeField] int duration;
    
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && PowerUpManager.Instance.state == 
                PowerUpManager.PowerUpState.NONE) {
            AchievementManager.Instance.shield = true;
            Pickup();
        }
    }

    void Pickup() {

        PowerUpManager.Instance.StartCoroutine(PowerUpManager.Instance.AddShield(duration));
        
        // Disable power up
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject);
    }

}
