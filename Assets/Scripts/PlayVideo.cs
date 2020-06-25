using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour
{

    public GameObject videoPlayer;
    public float timeToStop;
    public AudioSource sound;
    bool end = false;
    float timer = 5.5f;

    // Use this for initialization
    void Start()
    {
        videoPlayer.SetActive(false);
    }
    void Update()
    {
        if (end)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Key")
        {
            if (sound)
            {
                sound.Stop();
            }
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
            end = true;
        }
    }
}