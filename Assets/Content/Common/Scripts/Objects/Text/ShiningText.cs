using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShiningText : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private TextMeshProUGUI textUI;
    [SerializeField, ReadOnly]
    private TextMeshPro text;
    public float cycleTime = 2.0f;

    private float _elapsedTime = 0.0f; 

    private bool play = false;

    [SerializeField] private bool playOnAwake = false;
    
    void Awake()
    {
        TryGetComponent(out textUI);
        TryGetComponent(out text);
        
        if (textUI == null == (text == null)) //It means both are null or both are not null, I write it for fun lol
        {
            Debug.LogWarning("Check the tmp/tmpUI component on " + gameObject.name);
        }
        
        play = playOnAwake;
    }

    void Update()
    {
        if(!textUI && !text) return;
        
        if(!play) return;
        
        _elapsedTime += Time.deltaTime;
        
        var cycleProgress = _elapsedTime % cycleTime / cycleTime;
        
        var alpha = Mathf.Abs(Mathf.Cos(cycleProgress * Mathf.PI));

        if(textUI)
        {
            Color color = textUI.color;
            color.a = alpha;
            textUI.color = color;
        }

        else if (text)
        {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }
        
    }

    public void SetShiningText(bool target)
    {
        play = target;
    }
}