using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] int counterMax;
    int counter;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject[] topos;
    [SerializeField] float deactivationTime;
    [SerializeField] float deactivation;
    bool active;
    [SerializeField] GameObject activeg;
    [SerializeField] Material defaultMat;
    [SerializeField] Material failMat;
    [SerializeField] Material activationMat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = 0;
        text.text = "Puntos: " + counter + "/" + counterMax;
        int k = Random.Range(0, topos.Length);
        activeg = topos[k];
        Activate(topos[k]);
    }

    // Update is called once per frame
    void Update()
    {
        deactivation += Time.deltaTime;
        if (deactivation >= deactivationTime)
        {
            int k = Random.Range(0, topos.Length);
            if (topos[k] != activeg)
            {
                deactivation = 0;
                Activate(topos[k]);
                activeg = topos[k];
            }
        }
    }

    void Activate(GameObject obj)
    {
        Deactivate(activeg);
        obj.GetComponent<Renderer>().material = activationMat;
        obj.GetComponent<Topo>().active = true;
    }

    void Deactivate(GameObject obj)
    {
        obj.GetComponent<Renderer>().material = failMat;
        obj.GetComponent<Topo>().active = false;
        StartCoroutine(FullDeactivation(obj));
    }

    void ActivateOk(GameObject obj)
    {
        DeactivateOk(activeg);
        obj.GetComponent<Renderer>().material = activationMat;
        obj.GetComponent<Topo>().active = true;
    }

    void DeactivateOk(GameObject obj)
    {
        obj.GetComponent<Renderer>().material = defaultMat;
        obj.GetComponent<Topo>().active = false;
        StartCoroutine(FullDeactivation(obj));
    }

    public void UpdateCounter(GameObject obj)
    {
        if (obj.GetComponent<Topo>().active)
        {
            counter += 10;

            if (counter < counterMax)
            {
                text.text = "Puntos: " + counter + "/" + counterMax;
                int k = Random.Range(0, topos.Length);
                if (topos[k] != activeg)
                {
                    deactivation = 0;
                    ActivateOk(topos[k]);
                    activeg = topos[k];
                }
            }
            else
            {
                SceneManager.LoadScene("Scene3");
            }
        }
    }

    IEnumerator FullDeactivation(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        if (!obj.GetComponent<Topo>().active)
        {
            obj.GetComponent<Renderer>().material = defaultMat;
        }
    }
}
