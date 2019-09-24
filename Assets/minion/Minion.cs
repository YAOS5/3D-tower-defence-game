using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    //public static readonly int REG_MINION_HEALTH = 100;
    public float health;
    public float armour;
    public float shield;
    public float speed;
    public float size;


    // Start is called before the first frame update
    void Start()
    {
        CreateMinion();
    }

    // Update is called once per frame
    void Update()
    {
        this.move();

        //destroys the object
        if (this.health<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void move()
    {
        this.transform.localPosition += Vector3.right * speed * Time.deltaTime;
    }

    //basic method, will be refined/broken down others for different types of minions
    //sets the health armour shield and speed
    public void CreateMinion()
    {
        if (this.size == 0)
        {
            float scale = Mathf.Pow(this.health/100, 1f / 3f);
            this.gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(size, size, size);
        }
    }

    public void ReceiveDamage(int damage)
    {
        if (this.shield>0)
        {
            if (damage <= this.shield)
            {
                this.shield -= damage;
            }
            else
            {
                this.shield = 0;
                this.health -= damage - this.shield;
            }
        }
        else
        {
            this.health -= damage / (100 + armour);
        }
    }

}
