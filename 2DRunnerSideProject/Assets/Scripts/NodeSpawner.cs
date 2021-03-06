using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    [Header("Unity References")]
    [SerializeField] GameObject primaryNode;
    [SerializeField] GameObject secondaryNode;
    [SerializeField] Transform topBorder;
    [SerializeField] Transform bottomBorder;

    [Header("Spawn Configuration")]
    [SerializeField] Vector2 randomTimeBetweenNodes = new Vector2(0.2f, 1.5f);
    [SerializeField] float maxDistanceBetweenNodes = 3f;
    [SerializeField] float spawnRangeMagnitude = 10f;
    [SerializeField] float spawnRate = 5f;


    private void Start()
    {
        StartCoroutine(SpawnNodes());
    }

    IEnumerator SpawnNodes()
    {
        while(true)
        {
            float randomY = Random.Range(bottomBorder.position.y, topBorder.transform.position.y);
            Vector3 randomPos = new Vector3(this.transform.position.x,
                                            randomY,
                                            this.transform.position.z);

            GameObject primaryNodeIns = Instantiate(primaryNode, randomPos, Quaternion.identity);

            float randomTime = Random.Range(randomTimeBetweenNodes.x, randomTimeBetweenNodes.y);
            yield return new WaitForSeconds(randomTime);

            randomPos.y = Random.Range(bottomBorder.position.y, topBorder.transform.position.y);

            randomPos.y = Mathf.Clamp(randomPos.y,
                                        primaryNodeIns.transform.position.y - maxDistanceBetweenNodes,
                                        primaryNodeIns.transform.position.y + maxDistanceBetweenNodes);

            Instantiate(secondaryNode, randomPos, Quaternion.identity);

            spawnRate = Random.Range(1f, 5f);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}