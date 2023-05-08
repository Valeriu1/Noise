using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public float startWait = 5f;
    public float spawnWait;
    public float waveWait;
    public GameObject zombie;
    public GameObject player;
    public YouDied youDied;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            
                //float minDistance = 30f;
                //float maxDistance = 35.0f;
                //float distance = Random.Range(minDistance, maxDistance);
                //float angle = Random.Range(-Mathf.PI, Mathf.PI);

                Vector3 spawnValues = player.transform.position;
                Vector3 spawnPosition = new(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                while (Vector3.Distance(spawnPosition, player.transform.position) < 50)
                {
                    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                }
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(zombie, spawnPosition, spawnRotation);
            
            yield return new WaitForSeconds(spawnWait);

            if (!youDied.isPlayerAlive)
            {
                Debug.Log("Game over");
                break;
            }
        }
    }
}
