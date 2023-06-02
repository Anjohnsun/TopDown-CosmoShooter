using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform _parent;

    [SerializeField] Chunk[] ChunkPrefabsEntry;
    [SerializeField] Chunk[] ChunkPrefabsExit;
    [SerializeField] Chunk[] ChunkPrefabsMiddle;
    [SerializeField] private int _lvlSize; 
    private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        chunkSpawn("entry");
        for (int i = 0; i < _lvlSize; i++)
        {   
            chunkSpawn("");
        }
        chunkSpawn("exit");
    }

    private void chunkSpawn(string section)
    {
        Chunk newChank;
        if (section == "entry")
        {
            newChank = Instantiate(ChunkPrefabsEntry[Random.Range(0, ChunkPrefabsEntry.Length)], _parent);
        }
        else if (section == "exit")
        {
            newChank = Instantiate(ChunkPrefabsExit[Random.Range(0, ChunkPrefabsExit.Length)], _parent);
        }
        else
        {
            newChank = Instantiate(ChunkPrefabsMiddle[Random.Range(0, ChunkPrefabsMiddle.Length)], _parent);
        }

        if (_spawnedChunks.Count == 0) newChank.transform.position = transform.position;
        else newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].EndLvl.position;
        _spawnedChunks.Add(newChank);
    }
    
}
