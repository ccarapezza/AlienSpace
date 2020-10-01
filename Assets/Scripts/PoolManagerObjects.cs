using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerObjects : MonoBehaviour
{
    public GameObject objPrefab;  //El objeto que vamos a estar reutilizando

    public int poolSize;          //Cuantos objetos se necesitaran

    private Queue<GameObject> objPool; //La "alberca" donde estarán los objetos

    void Start()
    {
        LoadPool();
    }

    private void LoadPool()
    {
        objPool = new Queue<GameObject>();  //Inicializamos la cola

        for (int i = 0; i < poolSize; i++) //Vamos a llenar la alberca en base al tamaño
        {
            //Instanciamos el objeto y lo guardamos en una varible temporal    
            GameObject newObj = Instantiate(objPrefab);
            PoolableObject poolableObject = newObj.GetComponent<PoolableObject>();
            if (poolableObject != null)
                poolableObject.SetPoolManager(this);
            objPool.Enqueue(newObj);   //Lo añadimos a la cola con Enqueue
            newObj.SetActive(false);    //Lo desactivamos ya que en ese momento no se requiere
        }
    }

    public GameObject GetObjFromPool(Vector3 newPosition, Quaternion newRotation)
    {
        if (objPool.Count < 1)
            LoadPool();

        //Se obtiene el 1er objeto disponible en la cola
        GameObject newObj = objPool.Dequeue();
        //Activamos el objeto, se activa su comportamiento
        newObj.SetActive(true);
        //Le damos la posición y rotación, en donde se necesita que este
        newObj.transform.SetPositionAndRotation(newPosition, newRotation);

        return newObj;
    }

    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);    //Lo desactivamos
        objPool.Enqueue(go); //Lo volvemos a añadir a la cola para reutilizarlo
    }
}