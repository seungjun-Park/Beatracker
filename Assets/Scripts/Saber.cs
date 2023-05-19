using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layer;
    private Vector3 prevPos;
    public float saberLength;

    void Start()
    {
        saberLength = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
     
        if (Physics.Raycast(transform.position, transform.forward * saberLength, out hit, saberLength, layer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            if (Vector3.Angle(transform.position - prevPos, hit.transform.position) > 130)
            {
                Destroy(hit.transform.gameObject);
            }
        }

        else
        {
            Debug.DrawRay(transform.position, transform.forward * saberLength, Color.red);
        }

        prevPos = transform.position;
    }
}
