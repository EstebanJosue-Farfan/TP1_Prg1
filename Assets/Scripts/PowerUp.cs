using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float recarga = 10f;

    Renderer rend;
    Collider col;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerController p = other.GetComponent<PlayerController>();
        if (p == null || p.BoostActivo) return;

        p.ActivarBoost();
        StartCoroutine(Recargar());
    }

    IEnumerator Recargar()
    {
        rend.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(recarga);
        rend.enabled = true;
        col.enabled = true;
    }
}