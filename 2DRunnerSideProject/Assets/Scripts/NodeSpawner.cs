using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    [SerializeField] GameObject primaryNode;
    [SerializeField] GameObject secondaryNode;


    [SerializeField] Vector2 randomTimeBetweenNodes = new Vector2(0.2f, 1.5f);
    [SerializeField] float spawnRangeMagnitude = 10f;

    Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;

        StartCoroutine(SpawnNodes());
    }

    IEnumerator SpawnNodes()
    {
        Instantiate(primaryNode, GetRandomPosition(), Quaternion.identity);

        float randomTime = Random.Range(randomTimeBetweenNodes.x, randomTimeBetweenNodes.y);

        yield return new WaitForSeconds(randomTime);

        Instantiate(secondaryNode, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        float randomHeight = Random.Range(mainCamera.transform.position.y - spawnRangeMagnitude, mainCamera.transform.position.y + spawnRangeMagnitude);

        Vector3 randomPos = new Vector3(this.transform.position.x,
                                        randomHeight,
                                        this.transform.position.z);

        return randomPos;
    }
}
