using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponAim : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //public Button AimButton;
    public GameObject GunHolder;

    public Vector3 aimDownSights;
    public Vector3 hipFire;
    public float aimspeed;

    public bool buttonPressed;



    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    /*
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSights, aimspeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, hipFire, aimspeed * Time.deltaTime);
        }
    } */

    private void Update()
    {
        if(buttonPressed)
        {
            AimView();
        }
        else
        {
            UnAimView();
        }
    }

    public void AimView()
    {
        GunHolder.transform.localPosition = Vector3.Slerp(GunHolder.transform.localPosition, aimDownSights, aimspeed * Time.deltaTime);
    }

    public void UnAimView()
    {
        GunHolder.transform.localPosition = Vector3.Slerp(GunHolder.transform.localPosition, hipFire, aimspeed * Time.deltaTime);
    }


}
