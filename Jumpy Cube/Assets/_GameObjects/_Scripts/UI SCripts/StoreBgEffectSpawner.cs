using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBgEffectSpawner : MonoBehaviour
{
    [Header("Spawner Data")]
    public float xMin;
    public float xMax;
    public float xVal;
    public float yVal;
    public float zVal;
    public Vector3 pos;

    [Header("Spawner Time Data")]
    public float nextSpawnDelay;
    public float currentTime;

    [Header("Probablility Data")]
    public float maxProb = 10;
    public float currentProb;

    GameObject spawnedObj;
    RectTransform spawnedObjRectT;

    ObjectPooler objectPooler;
    
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        currentTime = 0;

        SpawnNewParticle();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > nextSpawnDelay)
        {
            currentTime = 0;
            SpawnNewParticle();
        }

        foreach(RectTransform t in objectPooler.storeBGEffectList)
        {
            if(t.localPosition.y > 610f)
            {
                t.transform.gameObject.SetActive(false);
            }
        }
    }

    void SpawnNewParticle()
    {
        xVal = Random.Range(xMin, xMax);
        pos = new Vector3(xVal, yVal, zVal);

        currentProb = Random.Range(1, maxProb);
        if (currentProb < 6)
        {
            spawnedObj = objectPooler.SpawnFormPool_UI("storeUIEffect_square");
        }
        else
        {
            spawnedObj = objectPooler.SpawnFormPool_UI("storeUIEffect_triangle");
        }
        spawnedObjRectT = spawnedObj.GetComponent<RectTransform>();
        spawnedObjRectT.localPosition = pos;
        spawnedObj.transform.rotation = Quaternion.identity;
        
        spawnedObj.GetComponent<StoreBgEffect>().Reset();
    }

}
