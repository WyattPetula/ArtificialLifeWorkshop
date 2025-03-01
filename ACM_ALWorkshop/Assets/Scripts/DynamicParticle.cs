using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicParticle : MonoBehaviour
{
    public float ship_force_add = 1.3f;
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

        foreach (DynamicParticle dp in dynamicBodiesArray)
        {
            if (dp == this)
                continue;

            float forceStrength = 0;
            switch (identifier)
            {
                case "Blue":
                    switch (dp.tag)
                    {
                        case "Blue": forceStrength = rules.bTB; break;
                        case "Yellow": forceStrength = rules.bTY; break;
                        case "Orange": forceStrength = rules.bTO; break;
                    }
                    break;
                case "Yellow":
                    switch (dp.tag)
                    {
                        case "Blue": forceStrength = rules.yTB; break;
                        case "Yellow": forceStrength = rules.yTY; break;
                        case "Orange": forceStrength = rules.yTO; break;
                    }
                    break;
                case "Orange":
                    switch (dp.tag)
                    {
                        case "Blue": forceStrength = rules.oTB; break;
                        case "Yellow": forceStrength = rules.oTY; break;
                        case "Orange": forceStrength = rules.oTO; break;
                    }
                    break;
            }

            if (forceStrength == 0)
                forceStrength = rules.oTB;

            Attract(dp, forceStrength);
        }
    }

    void Attract(DynamicParticle objectToAttract, float forceStrength)
    {
        if (forceStrength == 0)
        return;

        Rigidbody2D rb2DToAttract = objectToAttract.rb2D;
        rb2DToAttract.AddForce((rb2D.position - rb2DToAttract.position).normalized * forceStrength);
    }
}
