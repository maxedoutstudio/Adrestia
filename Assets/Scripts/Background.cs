using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public GameObject prefab, spaceContainer;

    private GameObject player;

    private float starDistance = 20.0f;
    public int spaceCount;

    public TextureInfo[] textures;

    [System.Serializable]
    public class TextureInfo
    {
        public int weight;
        public int count;
        public float minSize, maxSize;
        public Texture tex;
        public Color color_a, color_b;

    }

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<FirstPersonController>().gameObject;

        spaceContainer = new GameObject("Stars");

        for (int i = 0; i<spaceCount; i++)
        {
            CreateSpaceObject(GetRandomTexture());
        }
	
	}

    private TextureInfo GetRandomTexture()
    {
        int total = 0;
        foreach(TextureInfo t in textures)
        {
            total += t.weight;
        }

        int r = Random.Range(0, total);
        int i = 0;

        foreach(TextureInfo t in textures)
        {
            i += t.weight;
            if (r < i)
            {
                return t;
            }
        }
        return null;
        
    }
	
	// Update is called once per frame
	void Update () {
        spaceContainer.transform.position = player.transform.position;
    }

    //Creates space object
    void CreateSpaceObject(TextureInfo t)
    {
        Vector3 pos = Random.onUnitSphere * starDistance;
        GameObject spaceObject = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
        spaceObject.transform.parent = spaceContainer.transform;
        spaceObject.transform.LookAt(new Vector3(0, 0, 0));

        float size = Random.Range(t.minSize, t.maxSize);
        spaceObject.transform.localScale = new Vector3(size, size, size);

        spaceObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = t.tex;

        Color col = Color.Lerp(t.color_a, t.color_b, Random.Range(0.0f, 1.0f));
        col.a = 1.0f;
        spaceObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = col;
        
    }
}
