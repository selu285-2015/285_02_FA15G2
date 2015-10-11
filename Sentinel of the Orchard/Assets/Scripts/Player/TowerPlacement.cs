using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour
{

    private MeshRenderer self;
    public GameObject prefab;
    public bool placeable = false;
    public float height;
    private Renderer selfRenderer;
    void Start ()
    {
        self = GetComponent<MeshRenderer>();
        selfRenderer = self;
        self.enabled = false;
    }
	// Update is called once per frame
	void Update ()
	{
	    height = self.transform.position.y;
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
	    if (Input.GetKey("1"))
	    {
	        self.enabled = true;
	    }
	    if (self.enabled && Input.GetKey("e") && self.transform.position.y > 6 && placeable)
	    {
	        GameObject newTower = Object.Instantiate(prefab);
	        newTower.transform.position = self.gameObject.transform.position;
	        self.enabled = false;
	    }
    }

    void OnTriggerEnter()
    {
        placeable = true;
    }

    void OnTriggerExit()
    {
        placeable = false;
    }
    
}
