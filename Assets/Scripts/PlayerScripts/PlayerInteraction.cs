using UnityEngine;
using System.Collections;
using System;

public class PlayerInteraction : MonoBehaviour
{
    private bool _interactionActive;
	
	void Start () 
    {

    }
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_interactionActive)
        {
            coll.SendMessage("IsTalking");
            //_interactionActive = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //_interactionActive = false;
        }
    }
}
