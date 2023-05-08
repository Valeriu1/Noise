using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public float startWait = 10f;
    public float spawnWait = 5f;
    public float minDistance = 30f;
    public float maxDistance = 50f;
    public GameObject zombie;
    public GameObject player;
    public YouDied youDied;


    // Start is called before the first frame update
    void Start()
    {
        youDied = GameObject.FindGameObjectWithTag("GameManager").GetComponent<YouDied>(); 
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
            while (Vector3.Distance(spawnPosition, player.transform.position) > maxDistance || minDistance < Vector3.Distance(spawnPosition, player.transform.position))
                {
                    spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                }
            NavMesh.SamplePosition(spawnPosition, out NavMeshHit hit, Mathf.Infinity, NavMesh.AllAreas);
            Vector3 myRandomPositionInsideNavMesh = hit.position;
            Quaternion spawnRotation = Quaternion.identity;
                Instantiate(zombie, myRandomPositionInsideNavMesh, spawnRotation);
            
            yield return new WaitForSeconds(spawnWait);

            if (!youDied.isPlayerAlive)
            {
                Debug.Log("Game over");
                break;
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
