using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    public float speed = 30;
    private PoolableObject poolableObject;
    // Start is called before the first frame update
    void Start()
    {
        poolableObject = GetComponent<PoolableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.x > GameCommonData.Instance.MaxVector.x
            || transform.position.x < GameCommonData.Instance.MinVector.x
            || transform.position.y > GameCommonData.Instance.MaxVector.y
            || transform.position.y < GameCommonData.Instance.MinVector.y) {

            poolableObject.ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyComponent enemy = collider.gameObject.GetComponent<EnemyComponent>();
        if (enemy != null) 
        {
            enemy.GetComponent<ShipComponent>().Damage(damage);
            poolableObject.ReturnToPool();
        }
    }
}
