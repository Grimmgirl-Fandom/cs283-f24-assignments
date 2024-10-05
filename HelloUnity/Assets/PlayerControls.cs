using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;

        transform.position = new Vector3(38, -6, (float).5);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(0, 0, (float).1);

        }
        else if (Input.GetKey("a"))
        {
            gameObject.transform.Rotate(0, -1, 0);


        }
        else if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(0, 0, (float)-.1);

        }
        else if (Input.GetKey("d"))
        {
            gameObject.transform.Rotate(0, 1, 0);

        }
        // gameObject.transform.Translate(0, 0, movementSpeed * Time.deltaTime);

    }

    }

