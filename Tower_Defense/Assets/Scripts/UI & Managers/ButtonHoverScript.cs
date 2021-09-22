using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class ButtonHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        FindObjectOfType<SoundManagerScript>().MouseOverButton();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        FindObjectOfType<SoundManagerScript>().ButtonPressed();
    }
}