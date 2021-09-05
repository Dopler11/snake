using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject foodPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        GameObject newFood = Instantiate(foodPrefab, screenPosition, Quaternion.identity);
        newFood.name = "Food";
        Destroy(gameObject);
    }

}
