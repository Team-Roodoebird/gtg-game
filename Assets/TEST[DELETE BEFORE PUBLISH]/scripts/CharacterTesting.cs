using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTesting : MonoBehaviour
{

    public Character Raelin;
    // Start is called before the first frame update
    void Start()
    {
        Raelin = CharacterManager.instance.createCharacter("Raelin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
