using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    public TextMesh textDebug;
    public GameObject crosshair;
    float counter=3;
    public FPSWalk fpswalk;
    public GameObject[] load = new GameObject[8];

    bool slotKey = false;
    // Start is called before the first frame update
    void Start()
    {

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
                //troca cor do crosshair
                //crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                
                //decrementa o contador 
                counter -= Time.deltaTime;
                //se o contador for < 0 chama a funça no objeto ButtonAction()
                if (counter < 0)
                {
                    hit.transform.gameObject.SendMessageUpwards("ButtonAction");
                    counter = 2;//reseta o contador
                }
            } // senao verifica se o objeto é com o tag andavel
            else if(hit.transform.gameObject.CompareTag("Walkable"))
            {
                //crosshair.GetComponent<Image>().CrossFadeColor(Color.blue, .5f, false, false);
                hit.transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1,.7f); ///Cor do pépé
                counter -= Time.deltaTime;
                if (counter < 0)
                {
                    //anda com o personagem até o ponto de caminhada
                    fpswalk.positionToGo = hit.transform.position;
                    counter = 2;//reseta o contador
                }
            }
            else if (hit.transform.gameObject.CompareTag("Key"))
            {
                counter -= Time.deltaTime;
                if (counter < 0)
                {
                    slotKey = true;
                    counter = 2;//reseta o contador
                }
            }
            else
            {
                //se nao for nada disso reseta o contador
                counter = 2;
                //pinta o crossrair de vermelho
                //crosshair.GetComponent<Image>().CrossFadeColor(Color.red, .5f, false, false);
            }
        }
        else
        {
            //se nao da raycast o crosshair some
            //crosshair.GetComponent<Image>().CrossFadeColor(Color.black, .0f, false, false);
        }

       
    }
}
