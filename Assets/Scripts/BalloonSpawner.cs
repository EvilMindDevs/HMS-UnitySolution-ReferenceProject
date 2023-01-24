using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalloonSpawner : MonoBehaviour
{
    [SerializeField]
    private float waitForSecs = 0.5f;
    [SerializeField]
    private float minInclusiveSpawnPoint = -3f;
    [SerializeField]
    private float maxInclusiveSpawnPoint = 3f;

    [HideInInspector]
    public bool isEndTheGame = false;

    public void StartSpawnBalloon()
    {
        StartCoroutine(SpawnIterator());
    }

    IEnumerator SpawnIterator()
    {  
        for (;;)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(waitForSecs);
        }
    }
    private void SpawnBalloon()
    {
        var position = new Vector3(UnityEngine.Random.Range(minInclusiveSpawnPoint, maxInclusiveSpawnPoint), 0, 0);
        GameObject balloon = ObjectPool.SharedInstance.GetPooledObject();
        SpawnAtPosition(position, balloon);

    }

    private void SpawnAtPosition(Vector3 position, GameObject balloon)
    {
        if (balloon != null && isEndTheGame == false)
        {
            balloon.transform.SetPositionAndRotation(position, this.transform.rotation);
            balloon.SetActive(true);
        }
        else if (balloon != null && isEndTheGame == true)
        {
            balloon.SetActive(false);
           
        }
        
    }
}
