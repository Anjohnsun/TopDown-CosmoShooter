using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] Chunk[] ChunkPrefabs;
    [SerializeField] private int _lvlSize; 
    [SerializeField] private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        for (int i = 0; i < _lvlSize; i++)
        {   
            chunkSpawn();
            Debug.Log("sdasd");
        }
        
    }

    private void chunkSpawn()
    {
        Chunk newChank = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        _spawnedChunks.Add(newChank);
        newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].EndLvl.position - newChank.BeginLvl.localPosition;
       
       
    }
    
}
