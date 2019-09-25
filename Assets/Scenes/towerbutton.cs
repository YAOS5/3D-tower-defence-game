using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerbutton : MonoBehaviour
{
    public GameObject fab;
    private GameObject canvas;
    private GameObject slot;
    private GameObject showcase;
    private GameObject towerdetail;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("towerlist");
        towerdetail = GameObject.Find("towerdetail");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Build()
    {
        slot = canvas.GetComponent<towerlist>().currentSlot;
        slot.GetComponent<slot>().tower=Instantiate(fab, slot.transform);
        slot.GetComponent<slot>().tower.transform.localPosition = new Vector3(0f, 0f, 0f);
        slot.GetComponent<slot>().tower.transform.localScale = new Vector3(slot.GetComponent<slot>().tower.transform.localScale.x/slot.transform.localScale.x, slot.GetComponent<slot>().tower.transform.localScale.y / slot.transform.localScale.y, slot.GetComponent<slot>().tower.transform.localScale.z / slot.transform.localScale.z);
    }
    public void Hover()
    {
        showcase = Instantiate(fab);
        fab.AddComponent<RotateObject>();
        showcase.transform.position = new Vector3(10000f, 10000f, 10000f);
        towerdetail.SetActive(true);
    }
    public void Hoveroff()
    {
        Destroy(showcase);
        towerdetail.SetActive(false);
    }
}
