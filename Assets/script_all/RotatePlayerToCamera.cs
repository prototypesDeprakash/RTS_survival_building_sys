using UnityEngine;

public class RotatePlayerToCamera : MonoBehaviour
{
    public Transform player;     // Reference to the player object you want to rotate
    public Camera mainCamera;    // Reference to the camera (usually the main camera)

    void Update()
    {
        // Get the forward direction of the camera
        Vector3 cameraForward = mainCamera.transform.forward;

        // Make sure the player only rotates horizontally by ignoring the Y-axis
        cameraForward.y = 0;

        if (Input.GetMouseButton(0))
        {
            Debug.Log("now_looking");
            // If there is any movement in the forward direction
            if (cameraForward.sqrMagnitude > 0.1f)
            {
                // Rotate the player to face the camera's forward direction smoothly
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(cameraForward), Time.deltaTime * 5f);
            }
        }
    }
}
