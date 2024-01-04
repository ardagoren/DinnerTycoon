using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool eliBos = true;
    public bool elindekiCorba;
    public bool elindekiTavuk;
    public bool elindekiEt;

    public Vector2 inputValue;

    public float moveSpeed = 5f;

    public Animator animator;

    float yatayYon;
    float dikeyYon;

    private void Update()
    {
        inputValue.x = Input.GetAxis("Horizontal");
        inputValue.y = Input.GetAxis("Vertical");

        animatorControls();

        if (!eliBos)
        {
            if(elindekiCorba)
            transform.GetChild(0).gameObject.SetActive(true);
            else if(elindekiTavuk)
                transform.GetChild(1).gameObject.SetActive(true);
            else if (elindekiEt)
                transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            if (transform.GetChild(0).gameObject.activeSelf)
                transform.GetChild(0).gameObject.SetActive(false);
            else if (transform.GetChild(1).gameObject.activeSelf)
                transform.GetChild(1).gameObject.SetActive(false);
            else if (transform.GetChild(2).gameObject.activeSelf)
                transform.GetChild(2).gameObject.SetActive(false);
        }

        //karakter ekran dışına çıkmasın
        Vector2 pos = transform.position;
        pos.y=Mathf.Clamp(transform.position.y, -4, 4);
        pos.x=Mathf.Clamp(transform.position.x, -9, 9);
        transform.position = pos;

    }

    private void FixedUpdate()
    {
        transform.position = (Vector2)transform.position + (inputValue * Time.fixedDeltaTime * moveSpeed);
    }

    void animatorControls()
    {
        animator.SetFloat("Horizontal", inputValue.x);
        animator.SetFloat("Vertical", inputValue.y);
        animator.SetFloat("speed", inputValue.sqrMagnitude);

        if (inputValue.x > 0)
        {
            dikeyYon = 0;
            yatayYon = 1;

        }
        if (inputValue.x < 0)
        {
            dikeyYon = 0;
            yatayYon = -1;

        }
        if (Mathf.Abs(inputValue.y) > 0 && inputValue.x > 0)
        {
            dikeyYon = 0;
            yatayYon = 1;
        }

        if (inputValue.y > 0 && inputValue.x == 0)
        {
            yatayYon = 0;
            dikeyYon = 1;

        }

        if (Mathf.Abs(inputValue.y) > 0 && inputValue.x < 0)
        {
            dikeyYon = 0;
            yatayYon = -1;
        }

        if (inputValue.y < 0 && inputValue.x == 0)
        {
            yatayYon = 0;
            dikeyYon = -1;

        }
        animator.SetFloat("dikeyYon", dikeyYon);
        animator.SetFloat("yatayYon", yatayYon);
    }
}
