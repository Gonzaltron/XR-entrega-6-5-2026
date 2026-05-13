using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Cube : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Vector3 spawnPoint;
    Vector3 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position = spawnPoint;
        int position = Random.Range(-5, 5);
        this.transform.position = this.transform.position + Vector3.left * position;
        dir =  new Vector3(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y, player.transform.position.z - this.transform.position.z).normalized;
        this.transform.rotation = Quaternion.LookRotation(dir);
        this.GetComponent<Rigidbody>().linearVelocity = dir * speed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
