using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject bulletImpactEffect;

    public void SetTarget(Transform target) {
        this.target = target;
    }

    // Update is called once per frame
    void Update() {
        if (target == null) {
            Destroy(gameObject); // bullet disappears if there is no target (e.g. if it reaches the exit during this frame call)
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // Remember when we were learning about collision detection?  This is the prior one
        if (direction.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target.transform);
    }

    void HitTarget() {
        GameObject particleEffect = Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(particleEffect, 0.5f);  // I think this makes the particle effect and destroys it after 0.5 seconds

        if (explosionRadius > 0f) {
            Explode();
        } else {
            Damage(target);
        }

        Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode() {
        // Returns a list of all colliders that were hit in the given radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // Only damages the enemies
        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


}
