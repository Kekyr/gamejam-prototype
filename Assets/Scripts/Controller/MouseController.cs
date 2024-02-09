using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MouseController : MonoBehaviour
{

    [SerializeField] private Vector2 collision;
    [SerializeField] private Transform player;
    public GameObject projectile;
    public float launchVelocity = 700f;


    void Start()
    {
        Assert.IsNotNull(player);   
    }

    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);


        var p1 = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        var playerCenter = new Vector2(player.position.x, player.position.y);

        var hitCenter = Physics2D.Raycast(p1, (p1 - playerCenter).normalized);

        var hit = Physics2D.Raycast(p1, Vector2.down);
        collision = (p1 - playerCenter).normalized;

        Debug.DrawLine(new Vector3(p1.x, p1.y, 0), 
                       new Vector3(hit.point.x, hit.point.y, 0),
                       Color.green);


        Debug.DrawLine(new Vector3(playerCenter.x, playerCenter.y, 0),
                       new Vector3(hitCenter.point.x, hitCenter.point.y, 0),
                       Color.red);
        
        if (!GameMaster.Instance.paused && Input.GetButtonDown("Fire1"))
        {
            GameObject ball = Instantiate(projectile, 
                                          new Vector3(playerCenter.x, playerCenter.y, 0),
                                          Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce((p1 - playerCenter).normalized * launchVelocity);
            Destroy(ball, 4);
        }

        //Debug.DrawLine(new Vector3(p1.x, p1.y, 0),
        //              new Vector3(0, 0, 0),
        //               Color.red);
    }
}
