using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCristal : MonoBehaviour
{
    [SerializeField] public AudioSource sonidoColectado;
    [SerializeField] public AudioClip sonidoColectadoClip;

    private void Start()
    {
        sonidoColectado = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("cristals", PlayerPrefs.GetInt("cristals", 0) + 1);
            sonidoColectado.PlayOneShot(sonidoColectadoClip);
            Debug.Log($"Has colectado {PlayerPrefs.GetInt("cristals", 0)} cristales");
            Destroy(gameObject);
        }
    }
}
