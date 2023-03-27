using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float damage;
    public float speed;
    public float maxDistance;
    public HashSet<LaserEffect> onHitEffects;

    private void Awake() {
        Destroy(gameObject, maxDistance/speed);
    }

    private void Update()
    {
        Vector3 distance = transform.forward * (Time.deltaTime * speed * 10);
        transform.position += distance;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Health health)) {
            health.DamageBy(damage);
            Destroy(gameObject);
        }
    }
}

public enum LaserEffect {}
