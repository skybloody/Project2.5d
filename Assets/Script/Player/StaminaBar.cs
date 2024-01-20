using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private float maxStamina = 100.0f;
    private float currentStamina;

    private float staminaRegenRate = 10.0f;
    private float staminaRegenDelay = 2.0f;
    private float timeSinceLastStaminaRegen;

    public float CurrentStamina
    {
        get { return currentStamina; }
    }

    private void Start()
    {
        currentStamina = maxStamina;
    }

    public void ReduceStamina(float amount)
    {
        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        timeSinceLastStaminaRegen = 0.0f;
    }

    public void RegenerateStamina()
    {
        if (Time.time - timeSinceLastStaminaRegen > staminaRegenDelay && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }
    }
}
