using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_generation : MonoBehaviour
{
    public GameObject wallPrefab;  // The wall (cube) prefab to be placed
  //  public MouseButton activateKey = 1;  // Key to activate wall placing mode
    public LayerMask groundLayer;  // Layer mask for detecting ground
    public float wallHeight = 3f;  // Public variable to control the height of the wall

    private bool isPlacing = false;  // Whether wall placing mode is active
    private GameObject currentWall;  // The wall being placed
    private Vector3 startPosition;  // Initial click position for the wall
    private Vector3 initialWallScale;  // Initial scale of the wall

    void Update()
    {
        // Toggle wall placing mode when the 'P' key is pressed
        if (Input.GetMouseButtonDown(1))
        {
            isPlacing = !isPlacing;
            if (!isPlacing && currentWall != null)
            {
                Destroy(currentWall);  // If exiting placing mode, destroy the current wall
            }
        }

        if (isPlacing)
        {
            HandleWallPlacing();
        }
    }

    void HandleWallPlacing()
    {
        // If left mouse button is pressed, create the wall
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                startPosition = hit.point;
                currentWall = Instantiate(wallPrefab, startPosition, Quaternion.identity);
                initialWallScale = currentWall.transform.localScale;
                currentWall.transform.localScale = new Vector3(initialWallScale.x, wallHeight, initialWallScale.z);
            }
        }

        // Dragging the mouse to expand the wall
        if (Input.GetMouseButton(0) && currentWall != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                Vector3 dragPosition = hit.point;
                Vector3 dragDelta = dragPosition - startPosition;

                if (Mathf.Abs(dragDelta.x) > Mathf.Abs(dragDelta.z))
                {
                    // Dragging more horizontally: Adjust the width (X-axis)
                    float newWidth = Mathf.Abs(dragDelta.x);
                    currentWall.transform.localScale = new Vector3(newWidth, wallHeight, initialWallScale.z);
                    currentWall.transform.position = new Vector3((startPosition.x + dragPosition.x) / 2, currentWall.transform.position.y, startPosition.z);
                }
                else
                {
                    // Dragging more vertically: Adjust the depth (Z-axis)
                    float newDepth = Mathf.Abs(dragDelta.z);
                    currentWall.transform.localScale = new Vector3(initialWallScale.x, wallHeight, newDepth);
                    currentWall.transform.position = new Vector3(startPosition.x, currentWall.transform.position.y, (startPosition.z + dragPosition.z) / 2);
                }
            }
        }

        // Release the mouse button to finalize placement
        if (Input.GetMouseButtonUp(0) && currentWall != null)
        {
            currentWall = null;  // Stop placing the wall
        }
    }
}