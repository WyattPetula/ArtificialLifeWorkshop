using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicParticle : MonoBehaviour
{
    public float relationshipForce;
    public string identifier;

    public static List<DynamicParticle> dynamicBodiesList;
    Rules rules;

    public Rigidbody2D rb2D;
    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        identifier = gameObject.tag;
        rules = GameObject.Find("Rules").GetComponent<Rules>();
    }
    
    void FixedUpdate()
    {
        DynamicParticle[] dynamicBodiesArray = FindObjectsByType<DynamicParticle>(FindObjectsSortMode.None);
        rb2D.AddForce(new Vector2(Random.Range(-rules.randomForce, rules.randomForce), Random.Range(-rules.randomForce, rules.randomForce)));

        foreach (DynamicParticle dp in dynamicBodiesArray)
        {
            if (dp == this)
                continue;

            float forceStrength = 0;
            switch (dp.tag)
            {
                case "Blue":
                    switch (identifier)
                    {
                        case "Blue": forceStrength = rules.bTB; break;
                        case "Yellow": forceStrength = rules.bTY; break;
                        case "Orange": forceStrength = rules.bTO; break;
                        case "Purple": forceStrength = rules.bTP; break;
                    }
                    break;
                case "Yellow":
                    switch (identifier)
                    {
                        case "Blue": forceStrength = rules.yTB; break;
                        case "Yellow": forceStrength = rules.yTY; break;
                        case "Orange": forceStrength = rules.yTO; break;
                        case "Purple": forceStrength = rules.yTP; break;
                    }
                    break;
                case "Orange":
                    switch (identifier)
                    {
                        case "Blue": forceStrength = rules.oTB; break;
                        case "Yellow": forceStrength = rules.oTY; break;
                        case "Orange": forceStrength = rules.oTO; break;
                        case "Purple": forceStrength = rules.oTP; break;
                    }
                    break;
                case "Purple":
                    switch (identifier)
                    {
                        case "Blue": forceStrength = rules.pTB; break;
                        case "Yellow": forceStrength = rules.pTY; break;
                        case "Orange": forceStrength = rules.pTO; break;
                        case "Purple": forceStrength = rules.pTP; break;
                    }
                    break;
            }

            Attract(dp, forceStrength);
        }
    }

    void Attract(DynamicParticle objectToAttract, float forceStrength)
    {
        Rigidbody2D rb2DToAttract = objectToAttract.rb2D;
        float distance = (rb2D.position - rb2DToAttract.position).magnitude;
        if(distance != 0)
            rb2DToAttract.AddForce((rb2D.position - rb2DToAttract.position).normalized * forceStrength / distance, ForceMode2D.Force);
    }
}
