using Complete;
using System.Collections;
using UnityEngine;

public class HealthRegenSystem : MonoBehaviour
{
    public string baseTankTag;
    public float healthIncrement = 2f;
    public float healthIncrementInterval = 1f;

    TankHealth tankHealth = null;
    private bool onRegenHealth = false;

    private void Start()
    {
        StartCoroutine("RegenerateHealth");
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator RegenerateHealth()
    {
        while (true)
        {
            if (tankHealth != null && onRegenHealth == true)
            {
                tankHealth.HealthIncrease(healthIncrement);
            }
            
            yield return new WaitForSeconds(healthIncrementInterval);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == baseTankTag)
        {
            onRegenHealth = true;
            tankHealth = other.gameObject.GetComponent<TankHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onRegenHealth = false;
        tankHealth = null;
    }
}
