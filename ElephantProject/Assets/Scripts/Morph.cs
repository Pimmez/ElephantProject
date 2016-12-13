using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Morph : MonoBehaviour {
   
	public GameObject FirstAnimal;
	public GameObject SecAnimal;
	private int count = 1;

    //VERWIJDER PLZ NA DEMO
    public Text text;

    void OnEnable()
    {
        SecAnimal.SetActive(false);
    }

	void Update()
	{
		if(InputManager.BButton())
			count++;

		if(count > 2)
			count = 1;

		ChangeAnimal();
	}

	void ChangeAnimal()
	{
		switch (count)
		{
		case 1:
			FirstAnimal.SetActive(true);
			SecAnimal.SetActive(false);
			text.text = "OlifantVanTim";
			break;
		case 2:
			FirstAnimal.SetActive(false);
			SecAnimal.SetActive(true);
			text.text = "CheetahVanTim";
            break;
		}
	}
}
