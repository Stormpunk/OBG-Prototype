using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float ammoCount;
    public float maxAmmoCount;
    // Players current ammo pool as well as the maximum ammo they return to after reload
    public float timeToReload;
    // delay between the start of reload and a fully loaded gun. 
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
    public Transform firePoint;
    public Animator anim;
    public bool isFiring;
    //player plays an animation when firing projectiles
    public float maxHealth = 3;
    public float playerHealth;
    public bool takesDamage;
    bool isDead;
    public GameObject deathScreen;
    Scene scene;
    public Text ammoText;
    

    //health for players
    private List<Image> hearts = new List<Image>();
    


    private void Start()
    {
        ammoCount = maxAmmoCount;
        maxAmmoCount = 10;
        timeBetweenShots = 0;
        maxTimeBetweenShots = 0.5f;
        timeToReload = 3f;
        playerHealth = maxHealth;
        isDead = false;
        scene = SceneManager.GetActiveScene();
        //initial setup of player abilities, player can fire immediately and starts at the highest ammo count.
    }
    private void Update()
    {
        ammoText.text = "Ammo:" + ammoCount.ToString();
        if(takesDamage == true)
        {
            StartCoroutine(ResetDamageBool());
            takesDamage = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            currentCharge += Time.deltaTime;
        }
        //begins charging of a shot
        if (Input.GetKeyUp(KeyCode.Space) && timeBetweenShots == 0 && currentCharge >= 3)
        {
            Object.Instantiate(chargeShot, transform.position, transform.rotation);
            ammoCount -= 3;
            currentCharge = 0f;
            timeBetweenShots = (maxTimeBetweenShots * 6);
            anim.SetBool("isFiring", true);
            isFiring = true;
            if(isFiring == true)
            {
                StartCoroutine(FiringToFalse());
                isFiring = false;
            }

        }
        //fires a charged shot if the fire key is held for long enough
        else if (Input.GetKeyUp(KeyCode.Space) && timeBetweenShots == 0 && currentCharge < maxCharge && ammoCount > 0)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                    enemy.rb.AddForce(Vector3.right * 1);
                }
            }
            //fires a standard shot if a charged shot is not created
            anim.SetBool("isFiring", true);
            isFiring = true;
            currentCharge = 0f;
            timeBetweenShots = (maxTimeBetweenShots);
            ammoCount -= 1f;
            if (isFiring == true)
            {
                StartCoroutine(FiringToFalse());
                isFiring = false;
            }
        }
        timeBetweenShots -= Time.deltaTime;
        if(timeBetweenShots <= 0)
        {
            timeBetweenShots = 0;
        }
        //prevents the firing delay from reaching negative numbers.
        if(ammoCount <= 0)
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
        //reloads the players gun if empty
        if (playerHealth <= 0)
        {
            Death();
        }
        if (isDead)
        {
            deathScreen.SetActive(true);
        }
        if(Input.GetKey(KeyCode.Space) && (isDead))
        {
            SceneManager.LoadScene(scene.name);
        }
    }
    IEnumerator FiringToFalse()
    {
        Debug.Log("Started Animation");
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isFiring", false);
        Debug.Log("Firing Animation is over");
    }
    IEnumerator ResetDamageBool()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isDamaged", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            playerHealth -= 1;
            anim.SetBool("isDamaged", true);
            takesDamage = true;
        }
        //damages the player when the enemy hits them
    }
    public void Death()
    {
        isDead = true;
    }
}
   

