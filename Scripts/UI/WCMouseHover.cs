using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WCMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject toolTip;

    void Awake()
    {
        if (toolTip)
        {
            toolTip.SetActive(false);
        }
        else
        {
            //.. Ignore It
            toolTip = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (toolTip)
        {
            toolTip.SetActive(true);
        }

        FindObjectOfType<WCSoundManager>().PlaySound("MouseHoverSound");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (toolTip)
        {
            toolTip.SetActive(false);
        }
    }
}
