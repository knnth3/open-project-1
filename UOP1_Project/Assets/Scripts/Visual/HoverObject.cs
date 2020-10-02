using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    // Public variables
    public Transform Center = null;
    [Min(0)]
    public float Frequency = 1; // Units are in milli-units per Second
    public Vector2 YBounds = Vector2.one; // Units are in milli-units

    // Private variables
    private Transform transformCache;

    void Start()
    {
        transformCache = this.transform;
    }

    void Update()
    {
        // Don't calculate if there is no specified center
        if (Center == null)
        {
            return;
        }

        float scalar = 2.0f * Mathf.PI * Frequency;
        Vector3 deltaPosition = Vector3.up * Mathf.Sin(scalar * Time.time);

        // Apply limits (optional: may be more optimal to just have an amplitude applied here)
        // although this is a quick and easy way to evaluate simple collisions

        // Using "Elvis Operator" rather than "IF" statement to reduce space
        deltaPosition.y = (deltaPosition.y > 0) ? 
            deltaPosition.y * YBounds.x : deltaPosition.y * YBounds.y;

        transformCache.position = Center.position + deltaPosition;
    }
}
