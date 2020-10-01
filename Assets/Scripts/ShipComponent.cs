using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour
{
    public int initialHp;
    public float speed;
    private int hp;
    private EnemyComponent enemyComponent;
    private TriggerController triggerController;
    private PoolableObject poolableObject;
    public int Hp
    {
       get { return hp; }
    }
    void Awake()
    {
        hp = initialHp;
    }
    void Start()
    {
        enemyComponent = GetComponent<EnemyComponent>();
        triggerController = GetComponent<TriggerController>();
        poolableObject = GetComponent<PoolableObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot() {
        triggerController.Shoot();
    }

    public void ReleaseShoot()
    {
        triggerController.ReleaseShoot();
    }

    public bool isDead(){
        return hp<1;
    }

    public bool isEnemy()
    {
        return enemyComponent!=null;
    }

    private void Kill(){
        hp = 0;
        if (poolableObject != null)
            poolableObject.ReturnToPool();
    }

    public void Damage(int damagePoints)
    {
        hp-=damagePoints;
        if (hp < 1) {
            Kill();
        }
    }
}
