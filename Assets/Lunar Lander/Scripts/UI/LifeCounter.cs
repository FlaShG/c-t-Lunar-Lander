using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LifeCounter : MonoBehaviour
{
    private static Text text;
    
	void Awake()
	{
        text = GetComponent<Text>();
	}
	
	public static void UpdateCounter(int lives)
	{
        text.text = lives + "";
	}
}
