using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpdrachtenLes2 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartCoroutine(MyCoroutineExample(2f));
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
