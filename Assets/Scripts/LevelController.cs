using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public PlayerComponent playerComponentPrefab;
    public List<EnemyComponent> enemiesPrefab;
    private Dictionary<EnemyType, PoolManagerObjects> poolManagerFictionary = new Dictionary<EnemyType, PoolManagerObjects>();
    private Vector2 enemySpawnPos;
    private Vector2 enemyLimitPos;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1));
        enemyLimitPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0));
        Vector3 startPos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.2f));
        startPos = new Vector3(startPos.x, startPos.y, 0);
        Instantiate(playerComponentPrefab, startPos, Quaternion.identity);

        foreach (var enemyPrefab in enemiesPrefab)
        {
            PoolManagerObjects poolManagerObjects = gameObject.AddComponent<PoolManagerObjects>();
            poolManagerObjects.objPrefab = enemyPrefab.gameObject;
            poolManagerObjects.poolSize = 10;

            poolManagerFictionary.Add(enemyPrefab.enemyType, poolManagerObjects);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            poolManagerFictionary[EnemyType.Orbe].GetObjFromPool(enemySpawnPos, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            poolManagerFictionary[EnemyType.BattleShip].GetObjFromPool(enemySpawnPos, Quaternion.identity);
        }
    }
}
