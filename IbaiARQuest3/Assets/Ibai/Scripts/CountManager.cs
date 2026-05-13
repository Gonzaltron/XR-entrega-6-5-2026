using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    [SerializeField] TMP_Text puntos;
    [SerializeField] int puntosC;
    [SerializeField] int maxPuntos;
    bool fin;
    public static CountManager Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntos = GameObject.FindAnyObjectByType<TMP_Text>();
        puntosC = 0;
        puntos.text = puntosC.ToString();
        maxPuntos = 10;
        puntos.text = puntosC.ToString();
        fin = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnLevelWasLoaded()
    {
        puntos = GameObject.FindAnyObjectByType<TMP_Text>();
    }

    public void Cubo()
    {
            puntosC++;
            puntos.text = puntosC.ToString();
            if (puntosC == maxPuntos)
            {
                Terminar();
            }
    }

    public void Bomba()
    {
        puntosC -= 2;
        puntos.text = puntosC.ToString();
    }

    void Terminar()
    {
        puntos.text = "Fin";
        fin = true;
        Time.timeScale = 0;
    }
}
