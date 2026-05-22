using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLevel()
    {
        if(this.transform.CompareTag("Nivel2"))
        {
            Level2();
        }
        else if(this.transform.CompareTag("Nivel1"))
        {
            Level1();
        }
    }

    void Level1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    void Level2()
    {
        SceneManager.LoadScene("Nivel2");
    }
}
