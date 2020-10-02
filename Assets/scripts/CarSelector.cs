using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarSelector : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(! EventSystem.current.IsPointerOverGameObject())
        {
            CarManager carManager = FindObjectOfType<CarManager>();
            if (carManager != null)
            {
                carManager.SelectObject(this.gameObject);
            }
        }
    }
}
