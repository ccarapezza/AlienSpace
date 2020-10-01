using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    private PoolManagerObjects poolManagerObjects;
    public void SetPoolManager(PoolManagerObjects poolManagerObjects)
    {
        this.poolManagerObjects = poolManagerObjects;
    }

    public void ReturnToPool(){
        poolManagerObjects.ReturnObjToPool(gameObject);
    }
}
