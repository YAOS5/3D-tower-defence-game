using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    private GameObject canvas;
    public GameObject tower;

    void Start()
    {
        canvas = GameObject.Find("towerlist");
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        canvas.SetActive(true);
        canvas.GetComponent<towerlist>().currentSlot= this.gameObject;
    }
}
