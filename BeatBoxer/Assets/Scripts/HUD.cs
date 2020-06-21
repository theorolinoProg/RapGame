using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject       HUDs;
    public GameObject   player1;
    public GameObject   player2;
    public Image[]      PlayerImage;
    public GameObject        imageHeart;
    private int         pixelX;
    private int         pixelY;


    void Start()
    {
        //pixelX = canvas.worldCamera.pixelWidth;
        //pixelY = canvas.worldCamera.pixelHeight;
        addHeartScreen(3);
        StartCoroutine(addHeartScreen(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator addHeartScreen(int NbHeart)
    {
        int i = 0;
        Transform transform = HUDs.transform;
        while (i < NbHeart)
        {
            Vector3 position = new Vector3(HUDs.transform.position.x + (i * 90), HUDs.transform.position.y, HUDs.transform.position.z);
            transform.position = position;

            GameObject heart = GameObject.Instantiate(imageHeart, position, Quaternion.identity) as GameObject;
            heart.transform.SetParent(HUDs.transform, false);
            i +=1 ;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
