using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] Transform firePoint;

    public ParticleSystem muzzleFlash;
    public ParticleSystem tripleShootMuzzleFlash;
    ParticleSystem defMuzzleFlash;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileForce = 20f;
    
    bool tripleShoot = false;

    void Start() {
        defMuzzleFlash = muzzleFlash;
    }
    
    public ParticleSystem GetDefMuzzleFlash() {
        return defMuzzleFlash;
    }

    public void SetTripleShoot(bool value) {
        tripleShoot = value;
    }

    void OnFire() {

        muzzleFlash.Play();

        if (tripleShoot) {

            GameObject projectile1 = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -45));
            Rigidbody2D projectileRb1 = projectile1.GetComponent<Rigidbody2D>();
            projectileRb1.AddForce((firePoint.right + firePoint.up) * projectileForce, ForceMode2D.Impulse);

            GameObject projectile2 = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D projectileRb2 = projectile2.GetComponent<Rigidbody2D>();
            projectileRb2.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);

            GameObject projectile3 = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 45));
            Rigidbody2D projectileRb3 = projectile3.GetComponent<Rigidbody2D>();
            projectileRb3.AddForce((-firePoint.right + firePoint.up) * projectileForce, ForceMode2D.Impulse);

        } else {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse); 
        }
        
    }

}