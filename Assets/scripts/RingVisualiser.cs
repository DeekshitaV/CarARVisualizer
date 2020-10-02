using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RingVisualiser : MonoBehaviour
{
    public GameObject ringObject;
    public ARRaycastManager raycastManager;
    Vector2 screenPoint;
    [HideInInspector] public Vector3 hitPoint;

    void Start()
    {
        screenPoint = new Vector2(Screen.width*0.5f, Screen.height * 0.5f);
        ringObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> planeHit = new List<ARRaycastHit>();
        if (raycastManager.Raycast(screenPoint, planeHit, TrackableType.Planes))
        {
            ringObject.transform.localPosition = planeHit[0].pose.position;
            ringObject.SetActive(true);
            hitPoint = planeHit[0].pose.position;
        }

    }
 }
