using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DicInspector : MonoBehaviour {
    public Image image;
    public Text nameKo;
    public Text nameEn;
    public Text exp;

    public void setContent(DicContent content) {
        if(content == null) {
            image.sprite = null;
            image.color = new Color(0, 0, 0, 0);

            nameKo.text = "";
            nameEn.text = "";
            exp.text = "";

            return;
        }

        image.sprite = content.sprite;
        image.color = new Color(255, 255, 255, 255);
        var info = content.info;

        if(info.isDiscovered == true) {
            nameKo.text = info.name_ko;
            nameEn.text = info.name_en;
        } else {
            nameKo.text = "???";
            nameEn.text = "???";
        }

        exp.text = info.exp;
    }

    public void setInit() {
        image.sprite = null;
        nameKo.text = "";
    }
}
