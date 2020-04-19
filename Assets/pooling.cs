using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooling : MonoBehaviour
{
    public static pooling instance;

    public ObjectPooling[] itemsToPool;
    private List<GameObject> poolObj;

    private
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        poolObj = new List<GameObject>();

        foreach (ObjectPooling item in itemsToPool)
        {
            for(int i = 0; i < item.poolAmount; i++)
            {
                GameObject obj = Instantiate(item.poolObject);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                poolObj.Add(obj);

            }
        }
    }

    public GameObject GetPoolObjects(string name)
    {
        for(int i = 0; i < poolObj.Count; i++)
        {
            if(poolObj[i].activeInHierarchy == false && poolObj[i].name == name)
            {
                return poolObj[i];
            }
        }

        foreach (ObjectPooling item in itemsToPool)
        {
            if(item.poolObject.name == name)
            {
                GameObject obj = Instantiate(item.poolObject);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                poolObj.Add(obj);
                return obj;
            }
        }
        return null;
    }
}

[System.Serializable]
public class ObjectPooling
{
    public string name;
    public int poolAmount;
    public GameObject poolObject;
    public bool Expland;
}