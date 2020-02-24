using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ImageDownloader : MonoBehaviour
{

    public float gazeTime = 3f;
    int i = 0;

    private float timer;

    private bool gazedAt;
    public string url = "";
    public GameObject quad;
    Texture2D img;

    private void Start()
    {

    }
    IEnumerator Loadimg()
    {
        yield return 0;
        WWW imgLink = new WWW(url);
        yield return imgLink;
        img = imgLink.texture;
        quad.GetComponent<Renderer>().material.mainTexture = img;

    }

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
        

        if (i == 0)
        {
            url = "https://i.imgsafe.org/59/598170a188.jpeg";

            StartCoroutine(Loadimg());
            i = i + 1;
        }
        else if (i == 1)
        {
            url = "https://i.imgur.com/NzYvZtI.jpg";

            StartCoroutine(Loadimg());
            i = i + 1;
        }

        else if (i == 2)
        {
         
            url = "https://i.imgsafe.org/59/598573360c.jpeg";
            StartCoroutine(Loadimg());
            i = 0;
        }
       
    }

}
