using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;

    void Start()
    {
        currentStamina = maxStamina;
    }

    public void UseStamina(float consumptionRate)
    {
        // ลดพลังงานตามอัตราที่กำหนด
        currentStamina -= consumptionRate * Time.deltaTime;

        // ตรวจสอบไม่ให้พลังงานติดลบ
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }
}
