using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public int i = 1;
    public LayerMask _layer;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            //int _layer = (0 << 9);
            //_layer = ~_layer;


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 100f, _layer);
            if (hit.collider != null && hit.transform.gameObject.GetComponent<TileScript>() != null)
            {
                if (hit.transform.gameObject.GetComponent<TileScript>().HasTower != true)
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
                else
                {
                    if (hit.transform.gameObject.GetComponent<TileScript>().SellCanvas.activeInHierarchy == true)
                    {
                        hit.transform.gameObject.GetComponent<TileScript>().SellCanvas.SetActive(false);
                        i++;
                    }
                    else
                    {
                        hit.transform.gameObject.GetComponent<TileScript>().SellCanvas.SetActive(true);
                        i--;
                    }
                    if (i < 0)
                    {
                        hit.transform.gameObject.GetComponent<TileScript>().SellCanvas.SetActive(false);
                        i++;
                    }
                }
            }

        }
    }
}
