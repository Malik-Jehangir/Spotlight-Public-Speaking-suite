using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class buttonpublic : MonoBehaviour
{

    public float gazeTime = 3f;


    private float timer;

    private bool gazedAt;

    // Use this for initialization
    void Start()
    {

    }

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
        SceneManager.LoadScene("SpotLight_ppt");
    }
}

