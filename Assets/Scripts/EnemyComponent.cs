using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType {
    Orbe,
    BlowFish,
    Beetle,
    Bapho,
    BattleShip
};

public class EnemyComponent : MonoBehaviour
{
    public EnemyType enemyType;
    public List<Transform> barrels;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Transform> GetActiveBarrels()
    {
        List<Transform> listRtn = new List<Transform>();
        foreach (var barrel in barrels)
        {
            if (barrel.gameObject.activeSelf)
                listRtn.Add(barrel);
        }
        return listRtn;
    }
}
