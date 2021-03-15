using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;

    public EaseTypes easeType;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            
            switch (easeType)
            {
                /*
                 * TODO: uncomment onderstaande code en zorg dat het werkt met enums ;)
                case 1: 
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuad);
                    break;
                
                case 2:
                    FindObjectOfType<TweenMachine>().MoveGameObject(gameObject, targetPosition, speed, Easings.EaseInQuart);
                    break;
                */
            }
    }
}
