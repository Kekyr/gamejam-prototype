using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PickupCollector : MonoBehaviour
{
    [SerializeField] private int pickupCounts = 0;
    [SerializeField] private HudUIController hudManager;
    
    void Start()
    {
        Assert.IsNotNull(hudManager);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            ++pickupCounts;
            hudManager.changeCollectorLabel(pickupCounts);
        }
    }
}
