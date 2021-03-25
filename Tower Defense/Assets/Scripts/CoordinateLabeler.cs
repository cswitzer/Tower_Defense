using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    // Coordinates come from current position in world space
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates(); // so coordinates will display in game mode
    }

    // Update is called once per frame
    void Update()
    {
        // script will only execute in play mode
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    void DisplayCoordinates()
    {
        // grab information from gameobject (tile which is a parent) pertaining to world coordinate position
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x); // displays increments of 1
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        // set the text for current instance of text mesh to corresponding coordinate
        label.text = coordinates.x.ToString() + "," + coordinates.y.ToString();
    }

    // changes the name of this object's instance to its coordinates
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
