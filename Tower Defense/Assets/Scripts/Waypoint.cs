using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;

    // Mouse click events are added here because our containing object (Tile) contains a collider, which is needed for mouse clicking events
   void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // If the tile allows for placing
            if (isPlaceable)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                // script is instanced among all tiles, so this instance of the tile is not placeable anymore
                isPlaceable = false;
            }
        }
    }
}
