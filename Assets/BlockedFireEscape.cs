using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockedFireEscape : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (door.GetComponent<DoorRotator>().isOpening)
        {
            text.GetComponent<Text>().enabled = true;
        }
    }
}
