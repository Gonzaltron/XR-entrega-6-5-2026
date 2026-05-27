using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int counterMax;
    int counter;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject[] topos;
    [SerializeField] float deactivationTime;
    float deactivation;
    bool active;
    GameObject activeg;
    [SerializeField] Material defaultMat;
    [SerializeField] Material correctMat;
    [SerializeField] Material failMat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = 0;
        text.text = "Puntos: " + counter + "/" + counterMax;
    }

    // Update is called once per frame
    void Update()
    { 
        if(deactivation >= deactivationTime)
        {
            deactivation = 0;
            int k = Random.Range(0, topos.Length);
            activeg = topos[k];
            Activate(topos[k]);
        }
    }

    void Activate(GameObject obj)
    {
        Deactivate(activeg);
        obj.transform.position.y = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.25f, obj.transform.position.z);
    }

    void Deactivate(GameObject obj)
    {

    }

    public void UpdateCounter(GameObject obj)
    {
        counter += 10;

        if (counter < counterMax)
        {
            text.text = "Puntos: " + counter + "/" + counterMax;
        }
        else
        {
            SceneManager.LoadScene("Escena3");
        }
    }
}
