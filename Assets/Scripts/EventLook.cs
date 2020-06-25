using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLook : MonoBehaviour
{
    public AudioSource sound;
    public GameObject toEnable;
    public Rigidbody rdb;
    public GameObject father;
    public Vector3 force;
    public float finPos;
    float initPos = 49.632f;

    void Start()
    {
        finPos = initPos + 0.100f;
    }
    //funcao que é chamada depois de um tempo olhando
    public void ButtonAction()
    {
        //toca o som escolhido
        if (sound)
        {
            sound.Play();
        }
        if (toEnable)
        {
            toEnable.SetActive(true);
        }
        //adiciona uma força no objeto selecionado
        if (rdb)
        {
            rdb.AddForce(force,ForceMode.Impulse);
        }
    }

    public void PullBook()
    {
        //toca o som escolhido
        if (sound)
        {
            sound.Play();
        }
        while (gameObject.transform.position.z < finPos)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, (gameObject.transform.position.z + 0.000002f));
        }
        father.transform.gameObject.SendMessageUpwards("GameAdvance", gameObject);
    }

    //se acontece uma colisao toca o som
    private void OnCollisionEnter(Collision collision)
    {
        if (sound)
        {
            sound.Play();
        }
    }

}
