using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanMonster : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] List<GameObject> monsters = new List<GameObject>();
    void Start()
    {
        SpawnMonster();
    }

    void SpawnMonster()
    {
        int monsterIndex = Random.Range(0, monsters.Count);

        GameObject go = Instantiate(monsters[monsterIndex], spawnPoint.position, spawnPoint.rotation, spawnPoint);
        go.transform.localScale = new Vector3(1 / transform.localScale.x, 1, 1 / transform.localScale.z);
    }
}
