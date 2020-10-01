using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : MonoBehaviour
{
    protected ShipComponent shipComponent;
    public float amplitude = 1f;
    public float frequency = 1f;
    protected float sinusoidAxis = 0f;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        shipComponent = GetComponent<ShipComponent>();
        sinusoidAxis = transform.position.x;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float y = transform.position.y + (shipComponent.speed*-Time.deltaTime);
        float x = transform.position.x + Mathf.Sin(frequency*Time.time) * Time.deltaTime * amplitude;       
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
