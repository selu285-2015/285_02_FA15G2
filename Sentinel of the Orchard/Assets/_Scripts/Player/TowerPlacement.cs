using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour
{

    private MeshRenderer self;
    public GameObject prefab;
    public bool placeable = false;
    public float height;
    public float displayheight;
    private Renderer selfRenderer;
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

        if (self.transform.position.y > 6 && placeable)
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
	    if (Input.GetKeyDown(Key) && inven.amountOfTesla > 0)
	    {
	        self.enabled = !self.enabled;
	    }
	    if (self.enabled && Input.GetKey("e") && self.transform.position.y > 6 && placeable)
	    {
	        GameObject newTower = Object.Instantiate(prefab);
	        newTower.transform.position = self.gameObject.transform.position;
	        self.enabled = false;
			inven.amountOfTesla--;
	    }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.isTrigger) return;
        if (other.CompareTag("Map") == false) placeable = false;
        else if(other.CompareTag("Map")) placeable = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.isTrigger) return;
        if (other.CompareTag("Map") == true) placeable = false;
    }
    
}
