using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size = 5;
    }

    [System.Serializable]
    public class PoolType
    {
        public int tileTypeIndex;
        public List<Pool> poolObject;
    }

    #region SingleTon
    public static TilePool Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public List<PoolType> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    string tileTag;

    private void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (PoolType poolType in pools)
        {


            for (int a = 0; a < poolType.poolObject.Count; a++)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for (int i = 0; i < poolType.poolObject[a].size; i++)
                {
                    GameObject obj;
                    obj = Instantiate(poolType.poolObject[a].prefab);

                    obj.SetActive(false);
                    obj.transform.parent = transform;

                    objectPool.Enqueue(obj);
                }
                poolDictionary.Add(poolType.poolObject[a].tag, objectPool);
            }
        }
    }

    public GameObject SpawnTile(int tileTypeIndex, Vector3 pos, Quaternion rot, int tileIndex = -1)
    {
        GameObject tile;
        Generate_TileTag(tileTypeIndex, tileIndex);
        tile = SpawnFormPool(tileTag, pos, rot);
        return tile;
    }

    public GameObject SpawnFormPool(string tileTag, Vector3 pos, Quaternion rot)
    {

        if (!poolDictionary.ContainsKey(tileTag))
        {
            Debug.Log(tileTag + " DOES NOT EXIST -----");
            return null;
        }

        GameObject objToSpawn = poolDictionary[tileTag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = pos;
        objToSpawn.transform.localRotation = rot;
        poolDictionary[tileTag].Enqueue(objToSpawn);

        return objToSpawn;
    }

    void Generate_TileTag(int tileType, int index)
    {
        if (tileType == 0)
        {
            tileTag = "tile" + tileType + "_" + 0;
        }
        else
        {
            if (index == -1)
            {
                tileTag = "tile" + tileType + "_" + Random.Range(0, 9);
            }
            else
            {
                tileTag = "tile" + tileType + "_" + index;
            }
        }
    }

}
