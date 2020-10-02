using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectManager : MonoBehaviour
{
    public static GameObject SelectedObject;
    public ARRaycastManager raycastManager;
    //public ARPlaneManager planeManager;
    public RingVisualiser ringVisualiser;
   
    void Start()
    {
        SelectedObject = null;
    }

    public void SelectObject(GameObject gameObject)
    {
        DeselectObject();
        SelectedObject = gameObject;
        SelectedObject.SetActive(true);

    }

    void Update()
    {
        if (ringVisualiser.ringObject.activeSelf && SelectedObject != null )
        {
            SelectedObject.transform.position = Vector3.Lerp(SelectedObject.transform.position , ringVisualiser.ringObject.transform.position , Time.deltaTime*2);
        }
    }
    public void DeselectObject()
    {
        if( SelectedObject != null )
        {
            SelectedObject = null;
        }
    }

  /*  void Update()
    {
        if( Input.touchCount > 0 )
        {
            Touch touch0 = Input.GetTouch(0);
            List<ARRaycastHit> allHits = new List<ARRaycastHit>();
             
            if( touch0.phase == TouchPhase.Began)
            {
                if(raycastManager.Raycast(touch0.position, allHits , TrackableType.Planes))
                {
                    gameObject.transform.position = allHits[0].pose.position;
                    gameObject.SetActive(true);
                    foreach (var plane in planeManager.trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }

                }
            }
        }
    } */
}
