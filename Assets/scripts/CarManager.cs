using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CarManager : MonoBehaviour
{
    public static event Action<GameObject> CarSelected;
    public static GameObject SelectedCar;
    //public ARPlaneManager planeManager;
    public RingVisualiser ringVisualiser;

    void Start()
    {
        SelectedCar = null;
    }

    public void SelectObject(GameObject gameObject)
    {
        SelectedCar = gameObject;
        SelectedCar.SetActive(true);

        Vector3 camForward = Camera.main.transform.forward;
        camForward = new Vector3(camForward.x, 0, camForward.z).normalized;

        Quaternion carRot = Quaternion.LookRotation(-camForward);
        SelectedCar.transform.rotation = carRot;

        CarSelected?.Invoke(gameObject);
    }

    void Update()
    {
        if (SelectedCar != null)
        {
            SelectedCar.transform.localPosition = Vector3.Lerp(SelectedCar.transform.localPosition, ringVisualiser.hitPoint, Time.deltaTime * 2);
        }
    }
    
}