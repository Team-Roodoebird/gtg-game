using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    public string characterName;

    public bool isMultiLayerCharacter { get { return renderers.renderer == null; } }

    /// <summary>
    /// The root is the container for all images related to the character in the scene. The root object.
    /// </summary>
    [HideInInspector] public RectTransform root;

    /// <summary>
    /// Create a new character.
    /// </summary>
    /// <param name="_name"></param>
    public Character(string _name)
    {
        CharacterManager cm = CharacterManager.instance;
        //locate the character prefab
        GameObject prefab = Resources.Load("Characters/Character[" + _name + "]") as GameObject;
        //spawn an instance of the prefab directly on the character panel
        GameObject ob = GameObject.Instantiate(prefab, cm.characterPanel);

        root = ob.GetComponent<RectTransform>();
        characterName = _name;

        //get renderedr(s)
        renderers.renderer = ob.GetComponentInChildren<RawImage>();
        if (isMultiLayerCharacter)
        {
            renderers.bodyRenderer = ob.transform.Find("bodyLayer").GetComponent<Image>();
            renderers.expressionRenderer = ob.transform.Find("expressionLayer").GetComponent<Image>();


        }
    }
    [System.Serializable]
    public class Renderers
    {
        /// <summary>
        /// used as the only image for a single layer character
        /// </summary>
        public RawImage renderer;

        //sprites use layers
        /// <summary>
        /// The body rendered for a multi leveled character
        /// </summary>
        public Image bodyRenderer;
        public Image expressionRenderer;
    }

    public Renderers renderers = new Renderers();
}
