using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutfak : MonoBehaviour
{
    public int corbaCount = 0;
    public int tavukCount = 0;
    public int etCount = 0;
    [SerializeField] TextMesh corbaText;
    [SerializeField] TextMesh tavukText;
    [SerializeField] TextMesh etText;

    [SerializeField] private GameObject player;
    private player playerScript;

    [SerializeField] private GameObject corba;
    [SerializeField] private GameObject tavuk;
    [SerializeField] private GameObject et;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        YemekSayilariYazdir();
        //corba 0'dan fazlaysa corba fotosu gözüksün
        if (corbaCount != 0)
        {
            corba.SetActive(true);
        }
        else
        {
            corba.SetActive(false);
        }

        //tavuk 0'dan fazlaysa tavuk fotosu gözüksün
        if (tavukCount != 0)
        {
            tavuk.SetActive(true);
        }
        else
        {
            tavuk.SetActive(false);
        }

        //et 0'dan fazlaysa et fotosu gözüksün
        if (etCount != 0)
        {
            et.SetActive(true);
        }
        else
        {
            et.SetActive(false);
        }


        Collider2D hitCorba = Physics2D.OverlapCircle(corba.gameObject.transform.position, 1f);
        //player çorbayı aldı
        if (corba.activeSelf && playerScript.eliBos && hitCorba.name == "player" && Input.GetKeyDown(KeyCode.E))
        {
            playerScript.eliBos = false;
            playerScript.elindekiCorba = true;
            corbaCount--;
        }

        Collider2D hitTavuk = Physics2D.OverlapCircle(tavuk.gameObject.transform.position, 1f);
        //player tavuğu aldı
        if (tavuk.activeSelf && playerScript.eliBos && hitTavuk.name == "player" && Input.GetKeyDown(KeyCode.E))
        {
            playerScript.eliBos = false;
            playerScript.elindekiTavuk = true;
            tavukCount--;
        }

        Collider2D hitEt = Physics2D.OverlapCircle(et.gameObject.transform.position, 1f);
        //player eti aldı
        if (et.activeSelf && playerScript.eliBos && hitEt.name == "player" && Input.GetKeyDown(KeyCode.E))
        {
            playerScript.eliBos = false;
            playerScript.elindekiEt = true;
            etCount--;
        }
    }

    void YemekSayilariYazdir()
    {
        corbaText.text = corbaCount.ToString();
        tavukText.text = tavukCount.ToString();
        etText.text = etCount.ToString();
    }
}
