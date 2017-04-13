using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class SKillScroll : MonoBehaviour {

    public Skill selectedSkill;

    public GameObject panel;

    public GameObject cellPrefab;

    public Hero hero;

    private ArrayList skillList;

    // Display Texts
    public Text skillName;
    public Text skillCostAndType;
    public Text skillDamage;
    public Text skillProficient;
    public Text skillDescription;
    public Text skillProficient1;
    public Text skillProficient2;
    public Text skillProficient3;
    public Text skillProficient1Prob;
    public Text skillProficient2Prob;
    public Text skillProficient3Prob;

    public Controller controller;

    public MessageBox messagebox;

    private string[] DamageTypeString = {"物理","法术"};
    private string[] SkillLevelString = {"初级","进阶","传奇"};
    private string[] SkillUsableString = {"通用","黑化","未黑化"};

	// Use this for initialization
	void Start () {
		selectedSkill = null;
        skillList = new ArrayList();
        init();
        cleanAllText();
        hero = controller.hero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void init()
    {
        // init xml
        //XmlDocument xml = new XmlDocument();
        //xml.Load(Application.dataPath + "/xml/Skills.xml");

        // Put all skills into skillList in order
        Fireball fireball = new Fireball();
        skillList.Add(fireball);
        //initSigleSkillWithXML(fireball, xml.GetElementById("skill_fireball"));

        // Loop and create cell
        int size = skillList.Count;
        for (int i=0;i<size;i++)
        {
            GameObject cell = Instantiate(cellPrefab);
            cell.name = "cell" + i.ToString(); 
            int idx = i;
            ((Button)(cell.transform.Find("Icon").gameObject.GetComponent<Button>())).onClick.AddListener(() => setSelectedSkill(idx));
            ((Image)(cell.transform.Find("Icon").gameObject.GetComponent<Image>())).sprite = Resources.Load<Sprite>(((Skill)skillList[i]).skillId);
			cell.transform.SetParent(panel.transform);
            cell.transform.Find("Locked").gameObject.SetActive(((Skill)skillList[i]).isLocked);
        }
    }

    private void initSigleSkillWithXML(Skill skill, XmlElement xmlEle)
    {
        skill.skillId = xmlEle.GetAttribute("id");
        skill.name = xmlEle.GetAttribute("name");
		skill.type =(SkillType) (int.Parse(xmlEle.GetAttribute("type")));
        skill.level = (SkillLevel)(int.Parse(xmlEle.GetAttribute("level")));
        skill.usable = (SkillUsable)(int.Parse(xmlEle.GetAttribute("usable")));
        skill.cost = int.Parse(xmlEle.GetAttribute("cost"));
        skill.damageFormula = xmlEle.GetAttribute("damage");
        skill.description = xmlEle.GetAttribute("description");
        skill.maxProficient = int.Parse(xmlEle.GetAttribute("max_proficient"));
        skill.proficient = int.Parse(xmlEle.GetAttribute("proficient"));
        skill.isLocked = bool.Parse(xmlEle.GetAttribute("is_locked"));
        skill.proficientInformation[0] = xmlEle.GetAttribute("proficient_1");
        skill.proficientInformation[1] = xmlEle.GetAttribute("proficient_2");
        skill.proficientInformation[2] = xmlEle.GetAttribute("proficient_3");
    }

    private void cleanAllText()
    {
        skillName.text = "";
        skillCostAndType.text = "";
        skillDamage.text = "";
        skillProficient.text = "";
        skillDescription.text = "";
        skillProficient1.text = "";
        skillProficient2.text = "";
        skillProficient3.text = "";
        skillProficient1Prob.text = "";
        skillProficient2Prob.text = "";
        skillProficient3Prob.text = "";
    }

    public void setSelectedSkill(int idx)
    {
        if (((Skill)skillList[idx]).isLocked)
        {
            cleanAllText();
            skillName.text = "未解锁";
            return;
        }
        selectedSkill = (Skill)skillList[idx];

        skillName.text = selectedSkill.name;
        skillCostAndType.text = DamageTypeString[(int)selectedSkill.type] + "/"
            + SkillLevelString[(int)selectedSkill.level] + "/"
            + SkillUsableString[(int)selectedSkill.usable]
            + "(Cost: " + selectedSkill.cost + ")";
        skillDamage.text = selectedSkill.damageFormula;
        skillProficient.text = "Proficient: " + selectedSkill.proficient + "/" + selectedSkill.maxProficient;
        skillDescription.text = selectedSkill.description;
        skillProficient1.text = selectedSkill.proficientInformation[0];
        skillProficient2.text = selectedSkill.proficientInformation[1];
        skillProficient3.text = selectedSkill.proficientInformation[2];

        float[] prob = selectedSkill.getProbability(controller.dice1);

        skillProficient1Prob.text = string.Format("{0:0.00}", prob[0]);
        skillProficient2Prob.text = string.Format("{0:0.00}", prob[1]);
        skillProficient3Prob.text = string.Format("{0:0.00}", prob[2]);
    }

    public void apply()
    {
        if (selectedSkill == null)
            return;
        if (selectedSkill.cost > hero.mp)
        {
            messagebox.show();
            return;
        }

        GameObject.Find("SkillScroll").SetActive(false);
		controller.setState (Controller.State.STATE_SKILL_APPLY);
    }
}
