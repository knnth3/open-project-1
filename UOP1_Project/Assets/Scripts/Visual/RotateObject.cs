using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Public variables
    public float Speed = 30; // Units are in Degrees per Second
    public Vector3 AxisOfRotation = Vector3.up;

    // Private variables
    private Transform transformCache;

    void Start()
    {
        transformCache = this.transform;
    }

    void Update()
    {
        // Calculate and apply next rotation
        Vector3 deltaRotation = (Speed * Time.deltaTime) * AxisOfRotation;
        transformCache.rotation *= Quaternion.Euler(deltaRotation);
    }
}
