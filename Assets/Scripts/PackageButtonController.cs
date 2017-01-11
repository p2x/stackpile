using UnityEngine;
using UnityEngine.UI;

public class PackageButtonController : MonoBehaviour {
    public int PackageQuantity {
        get { return PackageQuantityValue; }
        set {
            if (value == PackageQuantityValue)
                return;
            PackageQuantityValue = value;
            if (Text != null)
                Text.text = PackageQuantityValue.ToString() + "x";
        }
    }

    public bool Enabled {
        get { return Button.IsInteractable(); }
        set { Button.interactable = value; }
    }

    public bool Selected {
        get { return SelectedValue; }
        set {
            if (value == SelectedValue)
                return;
            SelectedValue = value;
            BorderBottom.SetActive(value);
        }
    }

    public GameObject Package { get; set; }

    private Button Button;
    private Text Text;
    private GameObject BorderBottom;
    private int PackageQuantityValue;
    private bool SelectedValue;

    // Use this for initialization
    void Start () {
        Button = gameObject.GetComponent<Button>(); 
        Text = Button.GetComponentInChildren<Text>();
        BorderBottom = Button.transform.Find("Bottom Border").gameObject;
        Text.text = PackageQuantityValue.ToString() + "x";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
