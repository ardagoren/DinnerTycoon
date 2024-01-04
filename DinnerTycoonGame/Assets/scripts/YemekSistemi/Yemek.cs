using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yemek : MonoBehaviour
{
    public LayerMask layerMask;
    public StateMachine StateMachine { get; set; }

    public Order Order { get; set; }
    public Preparing Preparing { get; set; }
    public Ready ready { get; set; }
    public Taken taken { get; set; }

    public GameObject yemekFotosu;
    public float pisirmeSuresi;

    public GameObject mutfak;

    public player playerScript;

    public Vector2 currentSpot;
    public GameObject yeniSpot;

    public bool yemekBitti;

    private void Awake()
    {
        
        playerScript = GameObject.Find("player").GetComponent<player>();
        
    }
    private void Start()
    {
        currentSpot = yemekFotosu.transform.position;
    }
    private void OnEnable()
    {
        StateMachine = new StateMachine();

        Order = new Order(this, StateMachine);
        Preparing = new Preparing(this, StateMachine);
        ready = new Ready(this, StateMachine);
        taken = new Taken(this, StateMachine);

        StateMachine.Initialize(Order);
    }

    private void Update()
    {
        StateMachine.currentYemekState.FrameUpdate();
    }


}
