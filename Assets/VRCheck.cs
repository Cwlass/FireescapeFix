using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using Valve.VR;

public class VRCheck : MonoBehaviour
{
    [SerializeField] GameObject steamVR;
    [SerializeField] GameObject cameraRig;
    [SerializeField] GameObject nonVRRig;
    private void Awake()
    {
        if (!SteamVR.active)
        {
            steamVR.SetActive(false);
            cameraRig.SetActive(false);
            nonVRRig.SetActive(true);
        }
    }

}
