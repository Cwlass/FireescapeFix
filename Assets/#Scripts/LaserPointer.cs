using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;
    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4                         
    public Transform cameraRigTransform;
    // 2
    // 4

    // 5
    public Transform headTransform;
    // 6

    // 7
    public LayerMask teleportMask;
    // 8
    private bool shouldTeleport;


    // Start is called before the first frame update
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;
        // 1
        // 2
 

    }

    // Update is called once per frame
    void Update()
    {
        // 1
        if (teleportAction.GetState(handType))
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                // 1

                // 3
                shouldTeleport = true;

            }
        }
        else // 3
        {
            laser.SetActive(false);


        }
        if (teleportAction.GetStateUp(handType) && shouldTeleport)
        {
            Teleport();
        }


    }
    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
    private void Teleport()
    {
        // 1
        shouldTeleport = false;
        // 2
        // 3
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        // 4
        difference.y = 0;
        // 5
        cameraRigTransform.position = hitPoint + difference;
    }


}
