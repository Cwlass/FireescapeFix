using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] private Text endScreen;
    [SerializeField]  GameObject leftHand;
    [SerializeField] GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = this.transform;
            GetComponent<Animation>().Play();
            endScreen.enabled = true;
            leftHand.SetActive(false);
            rightHand.SetActive(false);

        }
    }
}
