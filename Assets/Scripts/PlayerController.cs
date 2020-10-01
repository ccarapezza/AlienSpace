using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipComponent))]
public class PlayerController : MonoBehaviour
{
    private ShipComponent shipComponent;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        shipComponent = GetComponent<ShipComponent>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            shipComponent.Shoot();
        if (Input.GetKeyUp(KeyCode.Space))
            shipComponent.ReleaseShoot();

        float x = Input.GetAxis("Horizontal")*shipComponent.speed*Time.deltaTime;
        float y = Input.GetAxis("Vertical")*shipComponent.speed*Time.deltaTime;

        transform.Translate(x, y, 0);

        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.07f, 0.93f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.85f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
