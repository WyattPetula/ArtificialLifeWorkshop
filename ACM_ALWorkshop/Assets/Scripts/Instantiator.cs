using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public int blueParticles;
    public int yellowParticles;
    public int orangeParticles;
    public int purpleParticles;

    public GameObject bluePrefab;
    public GameObject yellowPrefab;
    public GameObject orangePrefab;
    public GameObject purplePrefab;
    void Start()
    {
        if(blueParticles > 0){
            for(int i = 0; i < blueParticles; i++)
                Instantiate(bluePrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        }
        if(yellowParticles > 0){
            for(int i = 0; i < yellowParticles; i++)
                Instantiate(yellowPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        }
        if(orangeParticles > 0){
            for(int i = 0; i < orangeParticles; i++)
                Instantiate(orangePrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        }
        if(purpleParticles > 0){
            for(int i = 0; i < purpleParticles; i++)
                Instantiate(purplePrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        }
    }
}
