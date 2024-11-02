using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGame : MonoBehaviour
{
    public int objectsCollected;
    public Collider collectables;
    Collider playerCollider;


    // Start is called before the first frame update
    void Start()
    {
        objectsCollected = 0;
        playerCollider = GetComponent<Collider>();




    }

    private void OnTriggerEnter(Collider stuff)
    {
        objectsCollected++;
        stuff.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {




    }



}
