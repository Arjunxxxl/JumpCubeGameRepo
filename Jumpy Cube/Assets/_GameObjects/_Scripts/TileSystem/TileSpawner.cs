using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public Transform player;

    [Header("Tile Spawn Data")]
    public int maxTilesOnScreen = 8;
    public float spawnX;
    public float tileLength;
    public float safeZone;

    [Header("Tiles data")]
    public int totalTilesTypes;
    public List<int> tileTypeSpawnPool;
    public List<int> tileTypeActivePool;
    public int lastTileIndex;
    public int tile_typeIndex;
    public int tilePrefabIndex;

    List<GameObject> activeTiles;
    GameObject spawnedTile;

    TilePool tilePool;

    // Start is called before the first frame update
    void Start()
    {
        tilePool = TilePool.Instance;
        activeTiles = new List<GameObject>();
        tileTypeSpawnPool = new List<int>();
        tileTypeActivePool = new List<int>();

        SetEachTileProbability();

        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        for(int i = 0; i<maxTilesOnScreen; i++)
        {
            if(i < 2)
            {
                SpawnTile(0);
            }
            else if(i == 2)
            {
                SpawnTile(11, 0);
            }
            else
            {
                SpawnTile(11, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.transform.position.x) - safeZone > (spawnX - (maxTilesOnScreen * tileLength)))
        {
            RemoveTile();
            SpawnTile();
        }
    }

    void SpawnTile(int index = -1, int tileIndex = -1)
    {
        tile_typeIndex = RandonTileTypeIndex();

        if (index == -1)
        {
            if (tileIndex == -1)
            {
                spawnedTile = tilePool.SpawnTile(tile_typeIndex, Vector3.left * spawnX, Quaternion.identity);
            }
            else
            {
                spawnedTile = tilePool.SpawnTile(tile_typeIndex, Vector3.left * spawnX, Quaternion.identity, tileIndex);
            }
        }
        else
        {
            if (tileIndex == -1)
            {
                spawnedTile = tilePool.SpawnTile(index, Vector3.left * spawnX, Quaternion.identity);
            }
            else
            {
                spawnedTile = tilePool.SpawnTile(index, Vector3.left * spawnX, Quaternion.identity, tileIndex);
            }
        }

        spawnX += tileLength;
        //spawnedTile.transform.parent = transform;
        activeTiles.Add(spawnedTile);
    }

    int RandonTileTypeIndex()
    {
        int randomIndex = 0;
        int val;

        randomIndex = Random.Range(0, tileTypeSpawnPool.Count - 1);

        val = tileTypeSpawnPool[randomIndex];

        tileTypeActivePool.Add(tileTypeSpawnPool[randomIndex]);
        tileTypeSpawnPool.RemoveAt(randomIndex);

        return val;
    }

    void RemoveTile()
    {
        GameObject tile_toRemove = activeTiles[0];
        tile_toRemove.SetActive(false);
        activeTiles.RemoveAt(0);

        tileTypeSpawnPool.Add(tileTypeActivePool[0]);
        tileTypeActivePool.RemoveAt(0);
    }

    void SetEachTileProbability()               //use this to introduce easy, medium and hard mode
    {
        for (int i1 = 0; i1 < totalTilesTypes; i1++)
        {
            tileTypeSpawnPool.Add(i1);
            tileTypeSpawnPool.Add(i1);
            tileTypeSpawnPool.Add(i1);
            tileTypeSpawnPool.Add(i1);
            tileTypeSpawnPool.Add(i1);
            tileTypeSpawnPool.Add(i1);
            tileTypeSpawnPool.Add(i1);
        }
    }

}
