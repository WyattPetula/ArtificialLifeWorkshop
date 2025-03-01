using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public int blueParticles;
    public int yellowParticles;
    public int orangeParticles;

    public GameObject bluePrefab;
    public GameObject yellowPrefab;
    public GameObject orangePrefab;
    void Start()
    {
        if(blueParticles > 0){
            for(int i = 0; i < blueParticles; i++)
                Instantiate(bluePrefab, transform.position, Quaternion.identity);
        }
        if(yellowParticles > 0){
            for(int i = 0; i < yellowParticles; i++)
                Instantiate(yellowPrefab, transform.position, Quaternion.identity);
        }
        if(orangeParticles > 0){
            for(int i = 0; i < orangeParticles; i++)
                Instantiate(orangePrefab, transform.position, Quaternion.identity);
        }
    }
}
