using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
    
{
    int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;

        transform.position = new Vector3(63, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(0,0,1);

        }
        else if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(-1, 0, 0);

        }
        else if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(0, 0, -1);

        }
        else if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(1, 0, 0);

        }
        else if (Input.GetKey("l"))
        {
            //change levels

            if (level == 2)
            {
                level = 1;
                transform.position = new Vector3(63, -3, 0);


            }
            else
            {
                level = 2;
                transform.position=new Vector3(73, -22, 0);

            }
            // gameObject.transform.Translate(0, 0, movementSpeed * Time.deltaTime);

        }

    }
}
