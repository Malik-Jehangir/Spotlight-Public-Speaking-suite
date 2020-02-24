using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AudioScript : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;

	// Use this for initialization
	void Start () {
        MusicSource.clip = MusicClip;
	}

    public float gazeTime = 3f;


    private float timer;

    private bool gazedAt;

    // Use this for initialization
   

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
            }
        }

    }

    public void PointerEnter()
    {
        //Debug.Log("Pointer ENTER");
        gazedAt = true;
    }

    public void PointerExit()
    {
        //Debug.Log("Pointer EXIT");
        gazedAt = false;
    }

    public void PointerDown()
    {
        MusicSource.Play();    }
}



