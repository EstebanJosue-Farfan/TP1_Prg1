using UnityEngine;

public class ZonaEntrega : MonoBehaviour
{
    public Color colorVictoria = Color.green;
    public ParticleSystem particulas;

    bool entregado;

    void OnTriggerEnter(Collider other) { Revisar(other); }
    void OnTriggerStay(Collider other) { Revisar(other); }

    void Revisar(Collider other)
    {
        if (entregado) return;

        Transportable t = other.GetComponent<Transportable>();
        if (t == null || t.EstaLlevado) return; // el jugador solo NO activa la victoria

        entregado = true;
        Renderer r = GetComponent<Renderer>();
        if (r != null) r.material.color = colorVictoria;
        if (particulas != null) particulas.Play();
        GameManager.Instance.Victoria();
    }
}