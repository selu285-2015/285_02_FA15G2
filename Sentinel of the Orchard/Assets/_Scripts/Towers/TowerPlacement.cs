using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour
{

    public MeshRenderer self;
    public GameObject prefab;
    public GameObject teslaGuide;
    public GameObject tikiGuide;
    public GameObject shotgunGuide;
    public bool placeable = true;
    public float height;
    public float displayheight;
    public Renderer selfRenderer;
    public string Key;
	private GameObject player;
	private PlayerInventory inven;
    void Start ()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		inven = player.GetComponent<PlayerInventory> ();
        self = GetComponent<MeshRenderer>();
        selfRenderer = self;
        self.enabled = false;
    }
	// Update is called once per frame
	void Update ()
	{
	    height = self.transform.position.y;


        self.gameObject.transform.position = new Vector3(self.gameObject.transform.position.x, displayheight, self.gameObject.transform.position.z);
        self.gameObject.transform.rotation = Quaternion.Euler(270, 0, 0);

        if (placeable)
	    {
            //self.material.color = Color.blue;
            foreach (Material mat in selfRenderer.materials)
            {
                mat.color = new Color(0,0,1, .4f);
            }
        }
	    else
	    {
            //self.material.color = Color.red;
            foreach (Material mat in selfRenderer.materials)
            {
                mat.color = new Color(1, 0, 0, .4f);
            }
        }
	    if (Input.GetKeyDown(Key) && inven.amountOfTesla > 0 && Key == "1")
	    {
	        self.enabled = !self.enabled;
            tikiGuide.GetComponent<MeshRenderer>().enabled = false;
            shotgunGuide.GetComponent<MeshRenderer>().enabled = false;
        }
		if (Input.GetKeyDown(Key) && inven.amountOfTiki > 0 && Key == "2")
		{
			self.enabled = !self.enabled;
            teslaGuide.GetComponent<MeshRenderer>().enabled = false;
            shotgunGuide.GetComponent<MeshRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(Key) && inven.amountOf3rdTower > 0 && Key == "3")
        {
            self.enabled = !self.enabled;
            teslaGuide.GetComponent<MeshRenderer>().enabled = false;
            tikiGuide.GetComponent<MeshRenderer>().enabled = false;
        }
        if (self.enabled && Input.GetKey("e") && placeable)
	    {
	        GameObject newTower = Object.Instantiate(prefab);
	        newTower.transform.position = self.gameObject.transform.position;
	        self.enabled = false;
			if(Key == "1")
				inven.amountOfTesla--;
            else if (Key == "2")
                inven.amountOfTiki--;
            else if (Key == "3")
                inven.amountOf3rdTower--;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.isTrigger) return;
        else if (other.CompareTag("Map")) placeable = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;
        else if (other.CompareTag("Wall")) placeable = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.isTrigger) return;
        if (other.CompareTag("Map")) placeable = false;
        else if (other.CompareTag("Wall") == true) placeable = true;
    }
    
}
