using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpdrachtenLes2 : MonoBehaviour
{
    [SerializeField] private float _moveTime;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartCoroutine(MyCoroutineExample(2f));
        if (Input.GetKeyDown(KeyCode.Alpha2))
            StartCoroutine(Opdracht2(_moveTime));
        if (Input.GetKeyDown(KeyCode.Alpha3))
            StartCoroutine(Opdracht3(_moveTime));
    }

    IEnumerator Opdracht2(float duration)
    {
        Vector3 target = transform.position + Vector3.up * 3;
        Vector3 startPosition = transform.position;
        Vector3 direction = target - startPosition;
        // percent is onze 'genormaliseerde' waarde tussen 0 en 1 
        float percent = 0;
        
        while (percent < 1)
        {
            // hier berekenen we op basis van tijd (en duratie) wat de volgende waarde van percent is.
            // 0 is het start punt, 1 het eind van de curve
            // percent verloopt dus eigenlijk altijd lineair ;)
            percent += Time.deltaTime / duration;
            
            // Vervolgens berekenen we op welke plek we van de curve moet zijn op basis van percent
            float easeStep = percent * percent * percent; // EaseInCubic
            
            // Hier kunnen we die waarde vervolgens toepassen op een parameter naar keuze
            transform.position = startPosition + (direction * easeStep);
            
            yield return null;
        }
        
        // Gezien we niet 100% controle hebben dat percent straks exact 1 is.
        // moeten we hier de parameter welke we aanpassen hard toewijzen aan het gewenste eindresultaat.
        transform.position = target;
    }
    
    IEnumerator Opdracht3(float duration)
    {
        // percent is onze 'genormaliseerde' waarde tussen 0 en 1 
        float percent = 0;
        
        while (percent < 1)
        {
            // hier berekenen we op basis van tijd (en duratie) wat de volgende waarde van percent is.
            // 0 is het start punt, 1 het eind van de curve
            // percent verloopt dus eigenlijk altijd lineair ;)
            percent += Time.deltaTime / duration;
            
            // Vervolgens berekenen we op welke plek we van de curve moet zijn op basis van percent
            float easeStep = 1 - Mathf.Pow(1 - percent, 4); // EaseOutQuart
            
            
            // Hier kunnen we die waarde vervolgens toepassen op een parameter naar keuze
            // bijvoorbeeld scale
            Vector3 vectorStep = new Vector3(
                Mathf.Clamp01(1f * easeStep),
                Mathf.Clamp01(1f * easeStep),
                Mathf.Clamp01(1f * easeStep));
            transform.localScale = vectorStep;
            
            // of rotatie
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(360f * easeStep, 0, 360));
            
            // de clamp is nodig zodat we niet vermenigvuldigen met 0 of op een infinity waarde komen ;)
            yield return null;
        }
        
        // Gezien we niet 100% controle hebben dat percent straks exact 1 is.
        // moeten we hier de parameter welke we aanpassen hard toewijzen aan het gewenste eindresultaat.
        transform.localScale = Vector3.one;
        transform.rotation = Quaternion.identity;
    }

    IEnumerator MyCoroutineExample(float duration)
    {
        // percent is onze 'genormaliseerde' waarde tussen 0 en 1 
        float percent = 0;
        
        while (percent < 1)
        {
            // hier berekenen we op basis van tijd (en duratie) wat de volgende waarde van percent is.
            // 0 is het start punt, 1 het eind van de curve
            // percent verloopt dus eigenlijk altijd lineair ;)
            percent += Time.deltaTime / duration;
            
            // Vervolgens berekenen we op welke plek we van de curve moet zijn op basis van percent
            
            // Hier kunnen we die waarde vervolgens toepassen op een parameter naar keuze
            
            yield return null;
        }
        
        // Gezien we niet 100% controle hebben dat percent straks exact 1 is.
        // moeten we hier de parameter welke we aanpassen hard toewijzen aan het gewenste eindresultaat.
    }
    
}
