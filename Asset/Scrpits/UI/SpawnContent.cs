using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnContent : MonoBehaviour {
    public Image buttonImage;
    public Image image;
    public AtomInfo info;
    public Text nameKoText;

    public Sprite sprite;

    public void setAtomInfo(AtomInfo info){
        this.info = info;
        var sprite = Resources.Load<Sprite>(info.imagePath);
        this.sprite = sprite;
        image.sprite = sprite;
        nameKoText.text = info.name_ko;
    }

    public void setButtonImage(Sprite sprite) {
        buttonImage.sprite = sprite;
    }

}
