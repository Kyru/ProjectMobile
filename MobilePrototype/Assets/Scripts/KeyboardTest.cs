using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTest : MonoBehaviour
{
    [SerializeField] Vector3[] positions;
    [SerializeField] GameObject bullet; 
    int actualPosition;
    int maxPosition;
    int minPosition;
    Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        minPosition = 0;
        maxPosition = positions.Length;
        actualPosition = 1;         // posición mitad
        transform.position = positions[actualPosition];

        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down"))
        {
            print("I pressed down");
            if (actualPosition - 1 >= minPosition)
            {
                actualPosition--;
                transform.position = positions[actualPosition];
            }
        }

        if (Input.GetKeyDown("up"))
        {
            print("I pressed up");
            if (actualPosition + 1 < maxPosition)
            {
                actualPosition++;
                transform.position = positions[actualPosition];
            }
        }
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}