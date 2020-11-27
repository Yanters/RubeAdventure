using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem smokeEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(smokeEffect.gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Could not find Component 'RubyController'!");
        }
    }
}
