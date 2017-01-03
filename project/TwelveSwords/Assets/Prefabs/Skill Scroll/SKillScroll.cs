using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKillScroll : MonoBehaviour {

    public Skill selectedSkill;

    public GameObject panel;

    public GameObject cellPrefab;

    public HeroContainer heroContainer;

    private ArrayList skillList;

	// Use this for initialization
	void Start () {
		selectedSkill = null;
        skillList = new ArrayList();
        init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void init()
    {
        // Put all skills into skillList in order
        skillList.Add(new Fireball());

        // Loop and create cell
        int size = skillList.Count;
        for (int i=0;i<size;i++)
        {
            GameObject cell = Instantiate(cellPrefab);
            cell.name = "cell" + i.ToString(); 
            ((Text)(cell.transform.Find("Name")).gameObject.GetComponent<Text>()).text = ((Skill)skillList[i]).name;
            int idx = i;
            ((Button)(cell.transform.Find("Icon").gameObject.GetComponent<Button>())).onClick.AddListener(() => setSelectedSkill(idx));
            cell.transform.parent = panel.transform;
            cell.SetActive(!((Skill)skillList[i]).isLocked);
        }
    }

    public void setSelectedSkill(int idx)
    {
        selectedSkill = (Skill)skillList[idx];
        Debug.Log("貌似正在思考" + ((Skill)skillList[idx]).name + "...");
    }
}
