using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnInspector : MonoBehaviour {
    public Image image;
    public Text name_ko;
    public Text name_en;
    public Text atomic_num;

   public void setContent(SpawnContent content) {
        if(content == null) {
            image.sprite = null;
            image.color = new Color(0,0,0,0);
            name_ko.text = "";
            name_en.text = "";
            atomic_num.text = "";

            return;
        }

        image.sprite = content.sprite;
        image.color = new Color(255, 255, 255, 255);
        var info = content.info;
        name_ko.text = info.name_ko;
        name_en.text = info.name_en;
        atomic_num.text = "원자 번호 " + info.atomic_num + "번";
    }

    public void setInit() {
        image.sprite = null;
    }
}
