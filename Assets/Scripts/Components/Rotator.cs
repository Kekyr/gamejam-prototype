using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationCount = 2f;

    void Update()
    {
        transform.Rotate(0, 0, 360 * rotationCount * Time.deltaTime);
    }
}
