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

    [Header("Tile Tire data")]
    public bool initialTile;
    public bool tireCompleted1;
    public bool tireCompleted2;
    public bool tireCompleted3;
    public bool tireCompleted4;
    public int dist_tire1 = 120;
    public int dist_tire2 = 180;
    public int dist_tire3 = 240;
    public int dist_tire4 = 300;

    List<GameObject> activeTiles;
    GameObject spawnedTile;

    int distance;

    TilePool tilePool;
    DistanceScore distanceScore;

    private void Awake()
    {
        initialTile = false;
        tireCompleted1 = false;
        tireCompleted2 = false;
        tireCompleted3 = false;
        tireCompleted4 = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        tilePool = TilePool.Instance;
        distanceScore = DistanceScore.Instance;

        activeTiles = new List<GameObject>();
        tileTypeSpawnPool = new List<int>();
        tileTypeActivePool = new List<int>();

        distance = distanceScore.distance;

        if (!initialTile)
        {
            AddInitialInitialLevelTiles();
            initialTile = false;
        }

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
                SpawnTile();
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
        distance = distanceScore.distance;

        Check_if_TireCompleted();

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

    void Check_if_TireCompleted()
    {
        if (!tireCompleted1)
        {
            if (distance > dist_tire1)
            {
                AddTire1Tiles();
                tireCompleted1 = true;
            }
        }

        if (!tireCompleted2)
        {
            if (distance > dist_tire2)
            {
                AddTire2Tiles();
                tireCompleted2 = true;
            }
        }

        if (!tireCompleted3)
        {
            if (distance > dist_tire3)
            {
                AddTire3Tiles();
                tireCompleted3 = true;
            }
        }

        if (!tireCompleted4)
        {
            if (distance > dist_tire4)
            {
                AddTire4Tiles();
                tireCompleted4 = true;
            }
        }
    }

    void AddInitialInitialLevelTiles()               //use this to introduce easy, medium and hard mode
    {
        for (int i1 = 0; i1 < 4; i1++)
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

    void AddTire1Tiles()
    {
        for (int i1 = 4; i1 < 6; i1++)
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

    void AddTire2Tiles()
    {
        for (int i1 = 6; i1 < 8; i1++)
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

    void AddTire3Tiles()
    {
        for (int i1 = 8; i1 < 11; i1++)
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

    void AddTire4Tiles()
    {
        for (int i1 = 11; i1 < totalTilesTypes; i1++)
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
