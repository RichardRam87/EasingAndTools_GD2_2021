using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpdrachtenLes1 : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 5;
    [SerializeField] private float _moveTime = 5;
    private Renderer _renderer;
    private Vector3 _endposition;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _endposition = transform.position + (Vector3.up * 3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartCoroutine(Opdracht2());
        if (Input.GetKeyDown(KeyCode.Alpha2))
            StartCoroutine(Opdracht3());
        if (Input.GetKeyDown(KeyCode.Alpha3))
            StartCoroutine(Opdracht4(_fadeTime));
        if (Input.GetKeyDown(KeyCode.Alpha4))
            StartCoroutine(Opdracht5(_endposition, _moveTime));
    }

    IEnumerator Opdracht2()
    {
        print("Ik start nu de coroutine");
        yield return new WaitForSeconds(0.5f);
        print("Coroutine Update");
        yield return new WaitForSeconds(0.5f);
        print("Coroutine Einde");
    }

    IEnumerator Opdracht3()
    {
        print("Ik start nu de coroutine");
        
        for (int i = 0; i < 10; i++)
        {
            print("Coroutine Update");
            yield return new WaitForSeconds(0.5f);
        }
        print("Coroutine Einde");
    }

    IEnumerator Opdracht4(float fadeTime)
    {
        
        print("Fade Start");
        Color c = _renderer.material.color;
        // we lopen van 0 naar 1. 0 is het startpunt, 1 is het eind
        float percent = 0; 
        while (percent < 1)
        {
            // bereken hoe ver we zijn richting het eind. Zo doen we er fadetijd over om van 0 naar 1 te gaan.
            percent += (Time.deltaTime / fadeTime);  
            
            // zet de fadeout op basis van het verloopt
            c.a = 1-percent;
            _renderer.material.color = c;
            yield return null;
        }

        c.a = 0; // we zetten m hier hard naar 0 om eventuele afronding/verminderingsfouten te voorkomen
        print("Fade Stop");
    }

    IEnumerator Opdracht5(Vector3 endposition, float moveTime)
    {
        Vector3 startPosition = transform.position;
        
        float percent = 0;
        
        while (percent < 1)
        {
            // bereken hoe ver we zijn richting het eind. Zo doen we er fadetijd over om van 0 naar 1 te gaan.
            percent += (Time.deltaTime / moveTime);

            // Lerp geeft de positie tussen A en B terug op basis van percent
            // 0 = startpunt
            // 1 = eindpunt
            transform.position = Vector3.Lerp(startPosition, endposition, percent);
            
            // andere optie is om de afstand tussen A en B te berekenen
            // Vector3 distance = endposition - startPosition;
            // transform.position = startPosition + (distance * percent);
            yield return null;
        }

        // hier zetten we m weer hard op de eindpositie om afrondingsfouten te voorkomen.
        transform.position = endposition;
    }
}
