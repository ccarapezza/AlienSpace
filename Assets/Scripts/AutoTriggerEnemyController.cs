using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTriggerEnemyController : MonoBehaviour
{
    public float dpm;
    private float time;
    private float currentTime;
    private PoolManagerObjects pool;
    private EnemyComponent enemyComponent;
    private bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<PoolManagerObjects>();
        enemyComponent = GetComponent<EnemyComponent>();
        time = 60 / dpm;
        currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > time)
        {
            currentTime = 0;
            foreach (var barrel in enemyComponent.GetActiveBarrels())
            {
                pool.GetObjFromPool(barrel.position, barrel.rotation);
            }
        }
    }
}
