using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .2f);
    }
}
