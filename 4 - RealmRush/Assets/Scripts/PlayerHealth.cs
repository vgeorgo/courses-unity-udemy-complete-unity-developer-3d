using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text textHealth = null;

    void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        UpdateText();
    }

    void UpdateText()
    {
        textHealth.text = health.ToString();
    }
}
