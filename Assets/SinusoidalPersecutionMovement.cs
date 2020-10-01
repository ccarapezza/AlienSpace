using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalPersecutionMovement : SinusoidalMovement
{
    public float distanceDetection = .4f;
    private bool persecution;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        RaycastHit2D[] collidersHits = new RaycastHit2D[1];
        int hits = Physics2D.RaycastNonAlloc(transform.position, Vector3.down, collidersHits, distanceDetection, 1 << LayerMask.NameToLayer("Player"));
        if (hits > 0)
        {
            persecution = true;
            transform.Translate(Vector3.down*shipComponent.speed*2*Time.deltaTime);
        }
        else 
        {
            if (persecution)
                sinusoidAxis = transform.position.x;

            persecution = false;
            base.Update();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, .1f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position - transform.forward * distanceDetection);
    }
}
