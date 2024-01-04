using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusenYemek : MonoBehaviour
{
    
    void Update()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position = transform.position - new Vector3(0,0.1f);
        transform.Rotate(0, 0, -1);
    }
}
