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
    public int totalTilesPerType;
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

        if(!player)
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
                SpawnTile(15);
            }
            else
            {
                SpawnTile();
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

    void SpawnTile(int index = -1)
    {
        tile_typeIndex = RandonTileTypeIndex();

        if (index == -1)
        {
            spawnedTile = tilePool.SpawnTile(tile_typeIndex, Vector3.left * spawnX, Quaternion.identity);
        }
        else
        {
            spawnedTile = tilePool.SpawnTile(index, Vector3.left * spawnX, Quaternion.identity);
        }

        spawnX += tileLength;
        //spawnedTile.transform.parent = transform;
        activeTiles.Add(spawnedTile);
    }

    int RandonTileTypeIndex()
    {
        if (totalTilesTypes <= 1)
        {
            return 0;
        }

        int randomIndex = lastTileIndex;

        while (randomIndex == lastTileIndex)
        {
            randomIndex = Random.Range(1, totalTilesTypes);
        }

        return randomIndex;
    }

    void RemoveTile()
    {
        GameObject tile_toRemove = activeTiles[0];
        tile_toRemove.SetActive(false);
        activeTiles.RemoveAt(0);
    }

}
