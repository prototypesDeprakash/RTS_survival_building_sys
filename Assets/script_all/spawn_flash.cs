using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_flash : MonoBehaviour
{
    public GameObject muzzleFlashPrefab; // Assign your muzzle flash prefab in the inspector
    public Transform spawnPoint; // Assign the gun barrel or spawn point in the inspector
    public float flashDuration = 0.5f; // Duration the muzzle flash stays active
    private GameObject muzzleFlashInstance;


    private bool isShooting = false;

    void Start()
    {
        // Instantiate the muzzle flash once and disable it initially
        muzzleFlashInstance = Instantiate(muzzleFlashPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        muzzleFlashInstance.SetActive(false);
    }

    void Update()
    {
        // Check if the left mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            if (!isShooting)
            {
                isShooting = true;
                StartCoroutine(SpawnMuzzleFlashRepeatedly());
            }
        }
        else
        {
            isShooting = false;
            muzzleFlashInstance.SetActive(false); // Disable muzzle flash when not shooting
        }
    }

    // Coroutine to spawn muzzle flashes repeatedly
    IEnumerator SpawnMuzzleFlashRepeatedly()
    {
        while (isShooting)
        {
            // Activate the muzzle flash
            muzzleFlashInstance.SetActive(true);

            // Wait for the flash duration before disabling it
            yield return new WaitForSeconds(flashDuration);

            // Disable the muzzle flash until the next shot
            muzzleFlashInstance.SetActive(false);

            // Wait for a frame before spawning again if still shooting
            yield return null;
        }
    }
}