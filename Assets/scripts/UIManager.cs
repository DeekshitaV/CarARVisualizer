using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    Vector3 carRot;
    float yRot;
    public GameObject panel;
    private void OnEnable()
    {
        CarManager.CarSelected += AssignRotation;
    }
    public void AssignRotation(GameObject go)
    {
        carRot = go.transform.eulerAngles;
        slider.value = 0f;
    }

    public void ChangeRotation( float value)
    {
        yRot = carRot.y;
        yRot += value;
        CarManager.SelectedCar.transform.localEulerAngles = new Vector3(carRot.x, yRot, carRot.z);
    }
    public void OpenColorPanel()
    {
        if( panel != null)
        {
            Animator animator = GetComponentInChildren<Animator>();
            if( animator != null)
            {
                bool panelOpen = animator.GetBool("PanelOpen");
                animator.SetBool("PanelOpen", !panelOpen);
            }
        }
    }

    public void ColorChange( RawImage image)
    {
        MeshRenderer[] rend = CarManager.SelectedCar.GetComponentsInChildren<MeshRenderer>();
        for( int i = 0; i < rend.Length ; i++ )
        {
            for( int j = 0; j < rend[i].materials.Length; j++ )
            {
                if (rend[i].materials[j].name == "Body (Instance)")
                {
                    rend[i].materials[j].color = image.color;
                }
            }
        }
    }
    
    public void DeselectObject()
    {
        if (CarManager.SelectedCar != null)
        {
            CarManager.SelectedCar = null;
        }
    }
}
