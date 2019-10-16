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
        public List<Sequence> level_sequence;
    }

    public LevelData level1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
