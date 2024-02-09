using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Start()
    {
        Assert.IsNotNull(player);
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, 
                                         player.position.y,
                                         transform.position.z);
    }
}
