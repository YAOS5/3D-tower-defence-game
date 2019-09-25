using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTowerManager : MonoBehaviour
{
    public GameObject defaultTower;
    // Start is called before the first frame update
    void Start()
    {
        createTower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createTower()
    {
        GameObject tower = Instantiate(defaultTower);
        tower.transform.position = this.transform.position;
    }
}
