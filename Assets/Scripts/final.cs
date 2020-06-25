using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour
{
    public FPSWalk fpswalk;
    public GameObject pepe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
        fpswalk.positionToGo = pepe.transform.position;
        }
    }
}
