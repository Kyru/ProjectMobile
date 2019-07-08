using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    [SerializeField] Vector3[] positions;
    int actualPosition;
    int maxPosition;
    int minPosition;
    Vector3 originalScale;
    int stationaryFingerId;

    void Start()
    {
        minPosition = 0;
        maxPosition = positions.Length;
        actualPosition = 1;         // posición mitad
        transform.position = positions[actualPosition];

        originalScale = transform.localScale;
    }
    void Update()
    {
        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (myTouches[i].phase == TouchPhase.Began)
            {
                if (myTouches[i].position.x < (Screen.width / 2) && myTouches[i].position.y < (Screen.height / 2))  // abajo izquierda
                {
                    if (actualPosition - 1 >= minPosition) actualPosition--;
                    transform.position = positions[actualPosition];
                }
                else if (myTouches[i].position.x < (Screen.width / 2) && myTouches[i].position.y > (Screen.height / 2))  // arriba izquierda
                {
                    if (actualPosition + 1 < maxPosition) actualPosition++;
                    transform.position = positions[actualPosition];
                }
            }
            else if (myTouches[i].phase == TouchPhase.Stationary)
            {
                if (myTouches[i].position.x >= (Screen.width / 2))         // parte derecha
                {
                    stationaryFingerId = myTouches[i].fingerId;
                    transform.localScale += new Vector3(0, 0, 0.1f);
                }
            }
            else if (myTouches[i].phase == TouchPhase.Moved && myTouches[i].fingerId == stationaryFingerId)
            {
                if (myTouches[i].position.x >= (Screen.width / 2))         // parte derecha
                {
                    transform.localScale += new Vector3(0, 0, 0.1f);
                }
            }
            else if (myTouches[i].phase == TouchPhase.Ended && myTouches[i].fingerId == stationaryFingerId)
            {
                transform.localScale = originalScale;
            }
        }
    }
}