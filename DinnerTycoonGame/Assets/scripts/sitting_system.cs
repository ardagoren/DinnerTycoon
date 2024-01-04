using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitting_system : MonoBehaviour
{
    public GameObject[] spotlar;
    public List<GameObject> spotListesi;

    public GameObject prefab;

    public Transform girişNoktasi;

    float counter;

    public int yemekCesidi = 1;
    void Start()
    {
        //spotlar liste çevrildi
         spotListesi = new List<GameObject>(spotlar);
    }

    
    void Update()
    {
         TimeHandler();

        
    }

    void InstantiatePrefab()
    {
       
        if (spotListesi.Count>0)
        {
            Instantiate(prefab, girişNoktasi.position, Quaternion.identity);

        }
        else
        {           
            CancelInvoke("InstantiatePrefab");
        }
    }

    void TimeHandler()
    {

        counter += Time.deltaTime;

        if (counter>5)
        {
            Invoke("InstantiatePrefab", 0);
            counter = 0;
        }     

    }

}
