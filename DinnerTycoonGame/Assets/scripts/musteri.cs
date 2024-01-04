
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class musteri : MonoBehaviour
{
    int spriteIndex;
    [SerializeField] private Sprite[,] SpriteArray2D;



    Transform target;

    [SerializeField] Sprite[] yukarıBakanSpriteArray;
    [SerializeField] Sprite[] sagaBakanSpriteArray;
    [SerializeField] Sprite[] solaBakanSpriteArray;
    [SerializeField] Sprite[] asagiBakanSpriteArray;


    sitting_system sittingSystem;


    NavMeshAgent agent;
    NavMeshObstacle obstacle;

    Yemek musteriYemegi;

    public event EventHandler MusteriKalkti;
    money moneyScript;
    void Start()
    {
        MusteriKalkti += ParaEkle;
    }

    private void Awake()
    {
        spriteIndex = UnityEngine.Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = yukarıBakanSpriteArray[spriteIndex];


        moneyScript = GameObject.Find("money").GetComponent<money>();

        //random olarak sittingSystem içindeki spot listesinden spot alıp target olarak koy, daha sonra spot listesinden sil
        sittingSystem = GameObject.Find("SittingSystem").GetComponent<sitting_system>();
        int spotIndex = UnityEngine.Random.Range(0, sittingSystem.spotListesi.Count);
        target = sittingSystem.spotListesi[spotIndex].gameObject.transform;
        sittingSystem.spotListesi.RemoveAt(spotIndex);

        //musteri yemeği seçildi
        int yemekIndex = UnityEngine.Random.Range(0, sittingSystem.yemekCesidi);
        musteriYemegi = target.GetChild(yemekIndex).GetComponent<Yemek>();


        //navmesh oturunca obstacle yürürken agent
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    
    void Update()
    {

        NavmeshHandle();
        
        
    }

    private void NavmeshHandle()
    {

        if (!musteriYemegi.yemekBitti) //yemek bittiyse ajana geçip obstacle deaktive et
        {
            if (agent.enabled)
                agent.SetDestination(target.position);

            if (agent.enabled && !agent.pathPending && agent.remainingDistance == 0f)
            {
                agent.enabled = false;
                obstacle.enabled = true;

                musteriYemegi.gameObject.SetActive(true);


                if (target.tag == "lookright")
                {
                    GetComponent<SpriteRenderer>().sprite = sagaBakanSpriteArray[spriteIndex];
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = solaBakanSpriteArray[spriteIndex];
                }

            }
        }
        else
        {
            MusteriKalkti?.Invoke(this, EventArgs.Empty); //para ekleme fonksiyonunu invokeladık
            obstacle.enabled = false;
            agent.enabled = true;
            agent.SetDestination(sittingSystem.girişNoktasi.position);
            GetComponent<SpriteRenderer>().sprite = asagiBakanSpriteArray[spriteIndex];
            musteriYemegi.yemekFotosu.transform.position = musteriYemegi.currentSpot;
            musteriYemegi.gameObject.SetActive(false);
            if (!agent.pathPending && agent.remainingDistance == 0f)
            {
                sittingSystem.spotListesi.Add(target.gameObject);
                musteriYemegi.yemekBitti = false;
                Destroy(gameObject);          
            }
        }
    }

    private void ParaEkle(object sender, EventArgs e)
    {
        if(musteriYemegi.gameObject.name=="corba")
        moneyScript.moneyCounter += 10;

        if (musteriYemegi.gameObject.name == "tavuk")
            moneyScript.moneyCounter += 30;

        if (musteriYemegi.gameObject.name == "et")
            moneyScript.moneyCounter += 50;
        moneyScript.aud.Play();
        MusteriKalkti -= ParaEkle;
    }

}
