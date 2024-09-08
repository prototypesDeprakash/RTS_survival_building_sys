using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float explosionForce = 500f;  // The force of the explosion
    public float explosionRadius = 5f;   // The radius in which the explosion will affect
    public int objhealth = 5;
    public int objhealthmax = 10;
    public Camera mainCamera;
    public zombie_health zombie_health;
    public int damage=1;
    //public Animator zombie_animator;
    //public AudioSource gunSound;  // Add reference to AudioSource

    // Dictionary to track hit counts for each object
    private Dictionary<GameObject, int> hitCounts = new Dictionary<GameObject, int>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Check if the left mouse button is pressed
        if (Input.GetMouseButton(0))
            
        {
            Debug.Log("gunsound");
          //  gunSound.Play();
            ShootRaycast();
        }
    }

    void ShootRaycast()
    {
        // Raycast from the camera towards the center of the screen
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("object"))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, hit.point, explosionRadius);
                  //  Debug.Log("Explosion force applied to: " + hitObject.name);
                }
            }

            // Check if the object hit has the tag "heavyobj"
            if (hitObject.CompareTag("heavyobj"))
            {
                // Get the zombie_health component from the hit object
                zombie_health hitZombieHealth = hitObject.GetComponent<zombie_health>();

                if (hitZombieHealth != null)
                {
                    // Reduce the health of the specific zombie hit
                    hitZombieHealth.currentHealth -= damage;
                    Debug.Log(hitObject.name + "'s health decreased to " + hitZombieHealth.currentHealth);

                    // Check if the zombie's health is below or equal to zero, then destroy the zombie
                    if (hitZombieHealth.currentHealth <= 0)
                    {
                        hitZombieHealth.animator.SetBool("dead", true);
                        Debug.Log(hitObject.name + " is dead.");
                    }
                }

                // Apply explosion force to the hit object if it has a Rigidbody
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, hit.point, explosionRadius);
                    Debug.Log("Explosion force applied to: " + hitObject.name);
                }
            }
        }
    }
}