using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    public bool isOpening;
    public Transform target;
    public float speed = 100f;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            Vector3 targetPosition = new Vector3(target.position.x,this.transform.position.y,target.position.z);
            transform.LookAt(targetPosition);
        }   
    }
}
