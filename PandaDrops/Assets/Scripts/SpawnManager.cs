using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] items;
    public float spawnTime;
    private Health _playerHealth;

    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        InvokeRepeating("Spawn",0,spawnTime);
    }
    void Spawn()
    {
        if(_playerHealth!=null)
        {
            if(_playerHealth.health<=0)
            {
                return;
            }
            int randomItem = Random.Range(0,items.Length);
            int randomX = Random.Range(0, spawnPositions.Length);
            Instantiate(items[randomItem],spawnPositions[randomX].position,Quaternion.identity);
        }
    }
}
