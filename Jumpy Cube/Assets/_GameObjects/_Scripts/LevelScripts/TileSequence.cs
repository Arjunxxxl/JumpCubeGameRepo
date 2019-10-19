using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSequence : MonoBehaviour
{

    [System.Serializable]
    public struct Sequence
    {
        public int tileType;
        public int tileIndex;
    }

    [System.Serializable]
    public struct LevelData
    {
        public int totalNumberOfTiles;
        public LevelNumbers levelNumbers;
        public List<Sequence> level_sequence;
    }

    public bool triggerLevelLoading;
    public LevelManager levelManager;
    public List<Sequence> currentSequence;
    public List<LevelData> levelData;

    Vector2 nextTile;
    
    #region SingleTon
    public static TileSequence Instance;
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        
        if(!levelManager)
        {
            levelManager = GetComponent<LevelManager>();
        }

        currentSequence = new List<Sequence>();
        LoadCurrentLevel();
    }
    #endregion

    private void Update()
    {
        if(triggerLevelLoading)
        {
            LoadCurrentLevel();
            triggerLevelLoading = false;
        }
    }

    public void LoadCurrentLevel()
    {
        currentSequence = new List<Sequence>();

        foreach (LevelData data in levelData)
        {
            if(data.levelNumbers == levelManager.selectedLevelNumber)
            {
                for(int i = 0; i < data.totalNumberOfTiles; i++)
                {
                    currentSequence = data.level_sequence;
                }
            }
        }
    }

    public Vector2 RequestNextTile()
    {
        if (currentSequence.Count == 0)
        {
            nextTile.x = -1;
            nextTile.y = -1;
        }
        else
        {
            nextTile.x = currentSequence[0].tileType;
            nextTile.y = currentSequence[0].tileIndex;

            currentSequence.RemoveAt(0);
        }

        return nextTile;
    }
}
