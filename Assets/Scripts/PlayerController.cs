using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ammoCount;
    public float maxAmmoCount;
    // Players current ammo pool as well as the maximum ammo they return to after reload
    public float timeToReload;
    // delay between the start of reload and a fully loaded gun. 
    public GameObject projectile;
    public GameObject chargeShot;
    // projectiles that differ in speed, ammo usage and damage.
    public float timeBetweenShots;
    public float maxTimeBetweenShots;
    // stops the players from spamming their goddamn shots like monkeys.
    public GameObject gun;
    //empty gameobject to instantiate projectiles in, as the script as is will instantiate projectiles inside the player otherwise
    //*ahem*... WHYYYYYYY?!
    private float currentCharge = 0f;
    private float maxCharge = 2f;
    //floats that determine whether the player fires a standard shot or a charged shot.
    public GameObject reloadText;


    private void Start()
    {
        ammoCount = maxAmmoCount;
        maxAmmoCount = 10;
        timeBetweenShots = 0;
        maxTimeBetweenShots = 0.5f;
        timeToReload = 5f;
        //initial setup of player abilities, player can fire immediately and starts at the highest ammo count.
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentCharge += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) && timeBetweenShots == 0)
        {
            ShootTheBastard();
        }
        timeBetweenShots -= Time.deltaTime;
        if(timeBetweenShots <= 0)
        {
            timeBetweenShots = 0;
        }
        if(ammoCount < 0)
        {
            timeToReload -= Time.deltaTime;
            reloadText.SetActive(true);
            if(timeToReload <= 0)
            {
                ammoCount = maxAmmoCount;
                timeToReload = 5;
                reloadText.SetActive(false);
            }
        }
    }
    private void ShootTheBastard()
    {
        if(currentCharge >= maxCharge && ammoCount > 0)
        {
            Object.Instantiate(chargeShot, transform.position, transform.rotation);
            ammoCount -= 3;
            currentCharge = 0f;
            timeBetweenShots = (maxTimeBetweenShots * 6);
        }
        else if(currentCharge < maxCharge && ammoCount > 0)
        {
            Object.Instantiate(projectile, transform.position, transform.rotation);
            currentCharge = 0f;
            timeBetweenShots = (maxTimeBetweenShots);
            ammoCount -= 1f;
        }
        else
        {
            ammoCount -= 1f;
        }
    }
   
}
