using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<WaveSO> _waves = new List<WaveSO>();
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyShootPrefab;
    [SerializeField] private GameObject _enemyFlyPrefab;
    [SerializeField] private GameObject _enemyAgrrPrefab;
    [SerializeField] private float timeBetweenWaves;
    public void StartWave(List<Transform> _spawns)
    {
        StartCoroutine(SpawnWaveCoroutine(_spawns));
    }
    private IEnumerator SpawnWaveCoroutine(List<Transform> _spawns)
    {
        for (int i = 0; i < _waves.Count; i++)
        {
            for (int m = 0; m < _waves[i].amountOfRAyCastTurrets; m++)
            {

                Instantiate(_enemyPrefab, _spawns[Random.Range(0, _spawns.Count)].position, Quaternion.identity);
            }
            for (int j = 0; j < _waves[i].amountOfCloseCombatTurrets; j++)
            {
                Instantiate(_enemyFlyPrefab, _spawns[Random.Range(0, _spawns.Count)].position, Quaternion.identity);
            }
            for (int k = 0; k < _waves[i].amountOfRocketTurrets; k++)
            {
                Instantiate(_enemyAgrrPrefab, _spawns[Random.Range(0, _spawns.Count)].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        yield return null;
    }
    
    public void StopWave()
    {
        StopAllCoroutines();
    }
    
}