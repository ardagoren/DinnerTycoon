using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSystem : MonoBehaviour
{
    float counter;
    [SerializeField] private GameObject[] prefabArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeHandler();
    }

    void InstantiatePrefab()
    {
        int yemekCesidiIndex =Random.Range(0, 3);
        int spawnIndex = Random.Range(-8, 9);
        Instantiate(prefabArray[yemekCesidiIndex], new Vector2(spawnIndex,6), Quaternion.identity);
    }
    void TimeHandler()
    {

        counter += Time.deltaTime;

        if (counter > 0.5f)
        {
            Invoke("InstantiatePrefab", 0);
            counter = 0;
        }

    }
}
