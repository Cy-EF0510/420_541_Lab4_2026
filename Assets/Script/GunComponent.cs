using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

   void Update()
    {
        // TODO add the logic to track player keeping the input down.
        
        //If player starts pressing on button
        if(Input.GetButtonDown("Fire1")){
            //Start charging
            chargeTime = 0f;
            isCharging = true;
        }

        //If player is holding the button
        if(Input.GetButton("Fire1")){
            // Increase charge time while the button is held
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        }

        //If player releases the shoot button
        if (Input.GetButtonUp("Fire1")) // If true
        {
            // Spawn bullet when Fire1 is released
            isCharging = false;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
       
        // TODO change that equation so that it adds an impulse that follows charge time
        float bulletImpulse = (chargeTime/ maxChargeTime) * bulletMaxImpulse;

        // An impulse is a force you apply on a object in a single instant.
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
    }
}
