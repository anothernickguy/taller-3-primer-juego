using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboSystem : MonoBehaviour
{
    public TextMeshProUGUI comboText;
    public float comboDuration = 2f;
    public int comboDamageThreshold = 5; // Umbral de combo para cambiar el valor de damage
    public int newDamageValue = 10; // Nuevo valor de damage cuando el combo alcanza el umbral

    private int comboCount = 0;
    private Coroutine comboCoroutine;

    private void Start()
    {
        comboText.text = "Combo: " + comboCount.ToString();
    }

    public void IncreaseCombo()
    {
        comboCount++;
        comboText.text = "Combo: " + comboCount.ToString();

        if (comboCount >= comboDamageThreshold)
        {
            // Cambiar el valor de damage en el script del Proyectil
            Proyectil[] proyectiles = FindObjectsOfType<Proyectil>();
            foreach (Proyectil proyectil in proyectiles)
            {
                proyectil.damage = newDamageValue;
            }
        }

        if (comboCoroutine != null)
            StopCoroutine(comboCoroutine);

        comboCoroutine = StartCoroutine(ResetCombo());
    }

    IEnumerator ResetCombo()
    {
        yield return new WaitForSeconds(comboDuration);
        comboCount = 0;
        comboText.text = "Combo: " + comboCount.ToString();
    }
}
