using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectSound;
    private int point = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            // collision.gameObject.SetActive(false);
            point = point + 1;
            pointText.text = "Point: " + point;
        }
        if (collision.gameObject.CompareTag("Cherries"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            point = point + 2;
            pointText.text = "Point: " + point;
        }
    }
}
