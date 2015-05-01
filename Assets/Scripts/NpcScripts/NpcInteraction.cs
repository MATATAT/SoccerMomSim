using UnityEngine;
using System.Collections;

public class NpcInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void IsTalking()
    {
        Debug.Log("You are talking to me, " + this.name);
    }
}
