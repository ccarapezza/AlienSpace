using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public float dpm;
    private float time;
    private float currentTime;
    private PoolManagerObjects pool;
    private PlayerComponent playerComponent;
    private bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<PoolManagerObjects>();
        playerComponent = GetComponent<PlayerComponent>();
        time = 60 / dpm;
        currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shoot)
            return;

        currentTime += Time.deltaTime;
        if (currentTime > time)
        {
            currentTime = 0;
            foreach (var barrel in playerComponent.GetActiveBarrels())
            {
                pool.GetObjFromPool(barrel.position, Quaternion.identity);
            }
        }
    }

    public void Shoot() 
    {
        shoot = true;
    }

    public void ReleaseShoot()
    {
        shoot = false;
        currentTime = time;
    }
}
