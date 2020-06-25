using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    public TextMesh textDebug;
    public GameObject crosshair;
    float counter=2;
    public FPSWalk fpswalk;
    public GameObject loadbar;
    public GameObject[] load = new GameObject[8];

    float part;
    float dec;
    int inc = 0;
    // Start is called before the first frame update
    void Start()
    {
        part = counter / 8;
        dec = counter - part;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // se o raio q sai da camera bate em alguma coisa
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //coloca o nome do objeto na frente do raio na saida de debug
            textDebug.text = hit.transform.name;
            //posiciona o crosshair no ponto de impacto do raio
            //crosshair.transform.position = hit.point;
            //crosshair.transform.forward = hit.normal;

            //faz o crosshair sempre se alinhar com a camera
            crosshair.transform.forward = transform.forward;

            //se o objeto tiver tag player (iteragivel)
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                //decrementa o contador 
                counter -= Time.deltaTime;counter -= Time.deltaTime;
                if (counter < dec)
                {
                    load[inc].SetActive(true);
                    dec -= part;
                    inc++;
                }
                //se o contador for < 0 chama a funça no objeto ButtonAction()
                if (counter < 0)
                {
                    load[7].SetActive(true);
                    hit.transform.gameObject.SendMessageUpwards("ButtonAction");
                    dec = counter - part;
                    inc = 0;
                    counter = 2;//reseta o contador
                }
            } // senao verifica se o objeto é com o tag andavel
            else if(hit.transform.gameObject.CompareTag("Walkable"))
            {
                hit.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .7f);
                counter -= Time.deltaTime;
                if (counter < dec)
                {
                    load[inc].SetActive(true);
                    dec -= part;
                    inc++;
                }
                if (counter < 0)
                {
                    load[7].SetActive(true);
                    //anda com o personagem até o ponto de caminhada
                    fpswalk.positionToGo = hit.transform.position;
                    dec = counter - part;
                    inc = 0;
                    counter = 2;//reseta o contador
                }
            }
            else if (hit.transform.gameObject.CompareTag("Book"))
            {
                counter -= Time.deltaTime;
                if (counter < dec)
                {
                    load[inc].SetActive(true);
                    dec -= part;
                    inc++;
                }
                if (counter < 0)
                {
                    load[7].SetActive(true);
                    hit.transform.gameObject.SendMessageUpwards("PullBook");
                    dec = counter - part;
                    inc = 0;
                    counter = 2;//reseta o contador
                }
            }
            else
            {
                //loadbar.SetActive(false);
                load[0].SetActive(false);
                load[1].SetActive(false);
                load[2].SetActive(false);
                load[3].SetActive(false);
                load[4].SetActive(false);
                load[5].SetActive(false);
                load[6].SetActive(false);
                load[7].SetActive(false);
                //loadbar.SetActive(true);
                dec = counter - part;
                inc = 0;
                //se nao for nada disso reseta o contador
                counter = 2;
                //pinta o crossrair de vermelho
            }
        }
        else
        {

        }

       
    }
}
