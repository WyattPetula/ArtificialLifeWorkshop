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
    void Start()
    {
        identifier = gameObject.tag;
        rules = GameObject.Find("Rules").GetComponent<Rules>();
    }
    
    void FixedUpdate()
    {
        if(!Input.GetKey(KeyCode.Space)){
            DynamicParticle[] dynamicBodiesArray = FindObjectsByType<DynamicParticle>(FindObjectsSortMode.None);

            // Yes, this code is unoptimized. No, I don't have time to fix it.
            foreach (DynamicParticle DynamicParticle in dynamicBodiesArray)
            {
                if (DynamicParticle == this) continue;
                
                if(identifier.Equals("Blue") && DynamicParticle.tag.Equals("Blue"))
                    Attract(DynamicParticle, rules.bTB);

                else if(identifier.Equals("Yellow") && DynamicParticle.tag.Equals("Yellow"))
                    Attract(DynamicParticle, rules.yTY);
                
                else if(identifier.Equals("Orange") && DynamicParticle.tag.Equals("Orange"))
                    Attract(DynamicParticle, rules.oTO);

                else if(identifier.Equals("Blue") && DynamicParticle.tag.Equals("Yellow"))
                    Attract(DynamicParticle, rules.bTY);

                else if(identifier.Equals("Blue") && DynamicParticle.tag.Equals("Orange"))
                    Attract(DynamicParticle, rules.bTO);

                else if(identifier.Equals("Yellow") && DynamicParticle.tag.Equals("Blue"))
                    Attract(DynamicParticle, rules.yTB);

                else if(identifier.Equals("Yellow") && DynamicParticle.tag.Equals("Orange"))
                    Attract(DynamicParticle, rules.yTO);

                else if(identifier.Equals("Orange") && DynamicParticle.tag.Equals("Yellow"))
                    Attract(DynamicParticle, rules.oTY);
                
                else Attract(DynamicParticle, rules.oTB);
            }
        }
    }

    void Attract(DynamicParticle objectToAttract, float forceStrength)
    {
        if(forceStrength != 0){
            Rigidbody2D rb2DToAttract = objectToAttract.rb2D;
            Vector2 direction = (rb2D.position - rb2DToAttract.position).normalized;
            Vector2 force = direction * forceStrength;
            rb2DToAttract.AddForce(force);
        }
    }
}
