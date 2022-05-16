using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible for adding and maintaining characters in the scene.
/// </summary>
public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    /// <summary>
    /// All character must be attached to a character panel.
    /// </summary>
    public RectTransform characterPanel;

    /// <summary>
    /// List of characters currently in our scene.
    /// </summary>
    public List<Character> characters = new List<Character>();

    /// <summary>
    /// Easy lookup for our characters.
    /// </summary>
    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();

    private void Awake()
    {
        instance = this;
    }

    public Character GetCharacter(string characterName, bool createCharacterIfDoesNotExist = true)
    {
        int index = -1;
        if(characterDictionary.TryGetValue(characterName, out index))
        {
            return characters[index];
        }
        else if(createCharacterIfDoesNotExist)
        {
            return createCharacter(characterName);
        }

        return null;
    }

    public Character createCharacter(string characterName)
    {
        Character newCharacter = new Character(characterName);

        characterDictionary.Add(characterName, characters.Count);
        characters.Add(newCharacter);

        return newCharacter;
    }
}
