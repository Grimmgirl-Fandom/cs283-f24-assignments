using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Collect : MonoBehaviour
{
    int objectsCollected;
    public Collider collectables;
    Collider playerCollider;
    public GameObject UI;
    public TMP_Text txt;



    // Start is called before the first frame update
    void Start()
    {
        objectsCollected = 0;
        playerCollider = GetComponent<Collider>();
       // txt = UI.GetComponent<TMP_Text>();




    }

    public float getNum()
    {
        return objectsCollected+1;
    }

    private void OnTriggerEnter(Collider stuff)
    {
        objectsCollected++;
        txt.text = "Bananas: " + objectsCollected;
        stuff.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Bananas: " + objectsCollected;
    }



}
