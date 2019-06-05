using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject)
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }
    // 1
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") || other.CompareTag("Grabable"))
        {
            SetCollidingObject(other);
            Debug.Log(other.transform.name);
        }
        
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Door") || other.CompareTag("Grabable"))
        {
            SetCollidingObject(other);
            Debug.Log(other.transform.name);
        }
        
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }
    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }
    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        // 4
        objectInHand = null;
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    // Update is called once per frame
    void Update()
    {
        // 1
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                if (collidingObject.CompareTag("Door"))
                {
                    Debug.Log("can open");
                    collidingObject.transform.parent.transform.parent.GetComponent<DoorRotator>().isOpening = true;
                    collidingObject.transform.parent.transform.parent.GetComponent<DoorRotator>().target = gameObject.transform;
                }
                Debug.Log("can interact");
                if (collidingObject.GetComponent<Rigidbody>() || collidingObject.CompareTag("Grabable"))
                {
                    GrabObject();
                    Debug.Log("can pickup");
                }

            }
        }

        // 2
        if (grabAction.GetLastStateUp(handType))
        {
            if (collidingObject.CompareTag("Door"))
            {
                collidingObject.transform.parent.transform.parent.GetComponent<DoorRotator>().isOpening = false;
                collidingObject.transform.parent.transform.parent.GetComponent<DoorRotator>().target = null;
            }
            if (objectInHand)
            {
                ReleaseObject();

            }
        }

    }
}
