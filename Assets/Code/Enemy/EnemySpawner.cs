using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float MinTime;
    [SerializeField] private float MaxTime;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform SpawnPos;
    [SerializeField] private Transform[] Points;

    private float _spawnTime;
    public bool StartSpawn = false;

    private void Update()
    {
        _spawnTime -= Time.deltaTime;
        if (_spawnTime <= 0 && StartSpawn)
        {
            var e = Instantiate(Enemy, SpawnPos.position, new Quaternion());
            e.GetComponent<EnemyMovement>().SetPoints(Points);
            _spawnTime = Random.Range(MinTime, MaxTime);
        }
    }
}
