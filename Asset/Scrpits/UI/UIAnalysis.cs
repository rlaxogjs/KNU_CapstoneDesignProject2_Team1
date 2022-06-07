using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIAnalysis : MonoBehaviour {

    public Text nameKo;
    public Text nameEn;
    public Text molFormula;
    public Image image;
    public Text exp;

    public UnityEvent expEvent;
    public bool isFirst = false;
   
    private void OnEnable() {
        var info = new AtomInfo();
        info.type = AtomInfo.ATOM_TYPE.NONE;
        analysisMol(info);
    }

    private void OnDisable() {
        
    }

    public void analysisMol(AtomInfo info) {
        if (info.type == AtomInfo.ATOM_TYPE.NONE) {
            image.sprite = null;
            image.color = new Color(0, 0, 0, 0);

            nameKo.text = "";
            nameEn.text = "";
            exp.text = "";
            molFormula.text = "";

            return;
        }

        var sprite = Resources.Load<Sprite>(info.imagePath);
        image.sprite = sprite;
        image.color = new Color(255, 255, 255, 255);

        nameKo.text = info.name_ko;
        nameEn.text = info.name_en;
        var strs = info.imagePath.Split('/');

        molFormula.text = strs[2];

        exp.text = info.exp;
    }

    public void onClickedAnalysisButton() {
        Debug.Log("@@@@@@@@@@@@@@@@@");
        var analyInfo = AnalysisZone.instance.analysis();
        if (analyInfo.type == AtomInfo.ATOM_TYPE.NONE) return;

        var infos = UIDict.instance.atomInfos;
        Debug.Log("@@@@@@@@@@@@@@@@@" + analyInfo.name_ko);

        int targetIndex = 0;
        for(int i = 0; i < infos.Count; i++) {
            if(infos[i].type == analyInfo.type) {
                targetIndex = i;
                break;
            }
        }
        var info = UIDict.instance.atomInfos[targetIndex];
        info.isDiscovered = true;
        UIDict.instance.atomInfos[targetIndex] = info;

        if(isFirst == false) {
            isFirst = true;
            expEvent.Invoke();
        }

        analysisMol(info);
    }

}
