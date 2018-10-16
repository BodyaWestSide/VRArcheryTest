using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public int size;

    private Queue<GameObject> pool;

    private void Awake()
    {
        pool = new Queue<GameObject>(size);
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject SpawnFromPool(Transform t)
    {
        GameObject objectToSpawn = pool.Dequeue();

        IPoolable pooledObj = objectToSpawn.GetComponent<IPoolable>();
        if (pooledObj != null)
        {
            pooledObj.Spawn(t);
            objectToSpawn.SetActive(true);
        }

        pool.Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
