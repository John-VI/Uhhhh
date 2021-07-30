using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class debugmenulister : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textpref;
    List<TextMeshProUGUI> options = new List<TextMeshProUGUI>();
    string[] filenames;
    public int selection = 0;
    public Color32 notselected;
    public Color32 selected;
    float vert;
    public TMP_FontAsset font;
    bool stopper = true;

    void Start()
    {
        // //int offset = 0;
	string[] 
	scenepaths = System.IO.Directory.GetFiles("Assets/Scenes", "*.unity");
        filenames = new string[scenepaths.Length];
        int i;
        for (i = 0; i < filenames.Length; i++)
	    filenames[i] = System.IO.Path.GetFileNameWithoutExtension
	 	(scenepaths[i]);
	
        for (i = 0; i < filenames.Length; i++)
	{
	    GameObject text;
	    text = new GameObject("NewOption");
	    text.transform.SetParent(this.transform, false);
	    text.transform.localScale = new Vector3(1, 1, 1);
	    options.Add(text.AddComponent<TextMeshProUGUI>());
	    options[i].SetText(filenames[i]);
	    options[i].font = font;
	    options[i].fontSize = 16;
	    options[i].color = (i == selection) ? selected : notselected;
	    options[i].overflowMode = TextOverflowModes.Overflow;
	    text.GetComponent<RectTransform>().sizeDelta = new Vector2(692, 16);
	    // text.GetComponent<RectTransform>().anchorMin = new Vector2(0,1);
	    text.transform.localPosition = new Vector2(0, 248 - i * 16);
	}
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxisRaw("Vertical");
	
        if (vert < 0 && stopper) {
            options[selection].color = notselected;
            ++selection;
	    if (selection >= filenames.Length)
                selection = 0;
            options[selection].color = selected;
        } else if (vert > 0 && stopper) {
    	    options[selection].color = notselected;
            --selection;
	    if (selection < 0)
                selection = filenames.Length - 1;
            options[selection].color = selected;
        }
        stopper = (vert == 0);
	if (Input.GetKeyDown(KeyCode.Return))
            UnityEngine.SceneManagement.SceneManager.
		LoadScene(filenames[selection]);
    }
}
