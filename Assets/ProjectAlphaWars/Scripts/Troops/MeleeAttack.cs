using Complete;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
    public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

    private void OnTriggerEnter(Collider other)
    {
        print("other");
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();
        if (!targetRigidbody)
            return;
        print("rigidBody");
        HealthSystem targetHealth = targetRigidbody.GetComponent<HealthSystem>();

        if (!targetHealth)
            return;

        Debug.Log("target");
    }
}
