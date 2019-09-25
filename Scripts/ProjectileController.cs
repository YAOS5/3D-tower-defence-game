using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Vector3 velocity;
    private Vector3 initialLocation;
    public int damageAmount = 50;
    public string tagToDamage;
    

    void Start()
    {
        initialLocation = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // will need to create a function to calculate the
        // direction (velocity) between the mobile target and itself
        velocity 
        this.transform.Translate(velocity * Time.deltaTime);
    }


    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount);

            // Destroy self
            Destroy(this.gameObject);
        }
    }


    // this function calculates the velocity (direction) depends on
    // the input position of the minion

    Vector3 calculateDirection(Vector3 minionLocation)
    {
        return minionLocation - initialLocation;
    }
}
