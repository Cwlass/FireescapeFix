﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderAnimation : MonoBehaviour {

    Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //anim.Play();
    }
}
