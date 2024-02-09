using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class HealthComponent : MonoBehaviour
{
    // [SerializeField] private int health = 100;
    private PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
        Assert.IsNotNull(player);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            // health = 0;
            player.OnDeath();
        }
    }
}
