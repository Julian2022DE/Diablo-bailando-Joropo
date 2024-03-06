using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Enemys : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject enemy_Prefab;
    [SerializeField] public bool can_Spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(0, spawnRate);
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (true)
        {
            yield return wait;

            Instantiate(enemy_Prefab, transform.position, Quaternion.identity);
        }
    }
}
