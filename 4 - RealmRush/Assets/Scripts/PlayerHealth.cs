using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text textHealth = null;
    [SerializeField] AudioClip damageSfx = null;

    AudioSource audioSource = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        UpdateText();
        audioSource.PlayOneShot(damageSfx);
    }

    void UpdateText()
    {
        textHealth.text = health.ToString();
    }
}
