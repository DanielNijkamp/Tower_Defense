using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    private int i = 1;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.GetComponent<TileScript>().ShopCanvas.activeInHierarchy == true)
                {
                    hit.transform.gameObject.GetComponent<TileScript>().ShopCanvas.SetActive(false);
                    i++;
                }
                else
                {
                    hit.transform.gameObject.GetComponent<TileScript>().ShopCanvas.SetActive(true);
                    i--;
                }
                if (i < 0)
                {
                    hit.transform.gameObject.GetComponent<TileScript>().ShopCanvas.SetActive(false);
                    i++;
                }

            }



        }

    }
}
