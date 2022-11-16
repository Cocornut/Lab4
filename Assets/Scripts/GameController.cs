using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rigidbody Asteroid;
    private float spawnWait = 2f;
    private float nextWait = 5f;


    void Start()
    {

        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {  
        yield return new WaitForSeconds(spawnWait);
        for (int i = 0; i < 5; i ++)
        {
            for (int j = 0; j < 5; j++)
            {
                Instantiate(Asteroid, new Vector3(Random.Range(-5, 5), 0, 15), transform.rotation);
                yield return new WaitForSeconds(1f);
            }  
            yield return new WaitForSeconds(nextWait);
        }




    }
}
