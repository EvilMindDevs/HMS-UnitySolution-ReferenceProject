using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Bu sýnýf balonlarý önceden instantiate ederek sürekli instantiate/destro edilen obje döngüsünden bizi kurtarýr.
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private int randomInt;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        PrePoolObjects();
    }

    public void PrePoolObjects()
    {
       
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        { 
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
           
        }
    }

    public GameObject GetPooledObject()
    {
        randomInt = UnityEngine.Random.Range(0, amountToPool);
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[randomInt].activeInHierarchy)
            {
                return pooledObjects[randomInt];
            }
            
        }
        return null;
    }
}
