using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puzzle1 : MonoBehaviour
{

    public GameObject bfly;
    public GameObject bspace;
    public GameObject bbeacon;
    public GameObject bphoto;
    public GameObject bstorm;
    public GameObject bdraw;
    public GameObject objective;
    GameObject lastSelected;
    bool reset = false;
    public float finPos;
    float initPos;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        initPos = bfly.transform.position.z;
        finPos = initPos + 0.100f;
        lastSelected = null;
    }
    void Update()
    {
        if(reset == true) {
            timer += Time.deltaTime;
            print(timer);
            if(timer >= 0.96f)
            {
                bbeacon.transform.position = new Vector3(bbeacon.transform.position.x, bbeacon.transform.position.y, initPos);
                bbeacon.transform.gameObject.SendMessageUpwards("ButtonAction");
                bdraw.transform.position = new Vector3(bdraw.transform.position.x, bdraw.transform.position.y, initPos);
                bdraw.transform.gameObject.SendMessageUpwards("ButtonAction");
                bspace.transform.position = new Vector3(bspace.transform.position.x, bspace.transform.position.y, initPos);
                bfly.transform.position = new Vector3(bfly.transform.position.x, bfly.transform.position.y, initPos);
                bphoto.transform.position = new Vector3(bphoto.transform.position.x, bphoto.transform.position.y, initPos);
                bstorm.transform.position = new Vector3(bstorm.transform.position.x, bstorm.transform.position.y, initPos);
                lastSelected = null;
                timer = 0f;
                reset = false;
            }
        }

    }

    // Update is called once per frame
    public void GameAdvance(GameObject active)
    {
        if (active == bbeacon && lastSelected == null)
        {
            lastSelected = bbeacon;
        }
        else if (active == bdraw && lastSelected == bbeacon)
        {
            lastSelected = bdraw;
        }
        else if (active == bspace && lastSelected == bdraw)
        {
            lastSelected = bspace;
        }
        else if (active == bfly && lastSelected == bspace)
        {
            lastSelected = bfly;
        }
        else if (active == bphoto && lastSelected == bfly)
        {
            lastSelected = bphoto;
        }
        else if (active == bstorm && lastSelected == bphoto)
        {
            objective.transform.gameObject.SendMessageUpwards("OpenDoor");
        }
        else
        {
            reset = true;
           
        }

    }
}
