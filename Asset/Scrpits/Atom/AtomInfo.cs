using System;
using UnityEngine;

[Serializable]
public struct AtomInfo  {
    public enum ATOM_TYPE {
        NONE, A_CARBON, A_CHLORINE, A_HELIUM, A_HYDROGEN, A_NEON,
        A_NITROGEN, A_OXYGEN, C2H2, C2H4, C2H6O_C2H5OH, C2H6O_CH3OCH3,
        C6H6, CH2O, CH3COOH, CH3OH, CH4, CL2, CO2, H2, H2O, H2O2, HCL,
        HCN, N2, NH3, O2, O3
    }
    public ATOM_TYPE type;
    public string imagePath;
    public string prefabsPath;

    public string name_ko;
    public string name_en;
    public string atomic_num;
    public string exp;

    public bool isDiscovered;
    public bool isMol;

    public static AtomInfo getAtomInfo(ATOM_TYPE type) {
        if (type == ATOM_TYPE.NONE) throw new UnityException("AtomType is NULL");

        var info = new AtomInfo();
        info.type = type;

        info.isDiscovered = true;
        info.isMol = true;
        var imagePathSouce = "Atom/Images/";

        switch (type) {
            case ATOM_TYPE.NONE:
                break;
            case ATOM_TYPE.A_CARBON:
                info.name_ko = "탄소";
                info.name_en = "carbon";
                info.atomic_num = "6";
                info.imagePath = imagePathSouce + "C";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.isMol = false;
                break;
            case ATOM_TYPE.A_CHLORINE:
                info.name_ko = "염소";
                info.name_en = "chlorine";
                info.atomic_num = "17";
                info.imagePath = imagePathSouce + "Cl";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.isMol = false;
                break;
            case ATOM_TYPE.A_HELIUM:
                info.name_ko = "헬륨";
                info.name_en = "helium";
                info.atomic_num = "2";
                info.imagePath = imagePathSouce + "He";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.isMol = false;
                break;
            case ATOM_TYPE.A_HYDROGEN:
                info.name_ko = "수소";
                info.name_en = "hydrogen";
                info.atomic_num = "1";
                info.imagePath = imagePathSouce + "H";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.isMol = false;
                break;
            case ATOM_TYPE.A_NEON:
                info.name_ko = "네온";
                info.name_en = "neon";
                info.atomic_num = "10";
                info.imagePath = imagePathSouce + "Ne";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.isMol = false;
                break;
            case ATOM_TYPE.A_NITROGEN:
                info.name_ko = "질소";
                info.name_en = "nitrogen";
                info.atomic_num = "7";
                info.imagePath = imagePathSouce + "N";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.isMol = false;
                break;
            case ATOM_TYPE.A_OXYGEN:
                info.name_ko = "산소";
                info.name_en = "oxygen";
                info.atomic_num = "8";
                info.imagePath = imagePathSouce + "O";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.isMol = false;
                break;
            case ATOM_TYPE.C2H2:
                info.name_ko = "에타인";
                info.name_en = "ethyne";
                info.imagePath = imagePathSouce + "C2H2";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "알카인 계의 탄화수소중 가장 간단한 형태의 화합물이다." +
                    "용도는 합성고무의 원료, 아세트산의 용매로 활용되고 있다.";
                break;
            case ATOM_TYPE.C2H4:
                info.name_ko = "에틸렌";
                info.name_en = "ethylene";
                info.imagePath = imagePathSouce + "C2H4";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "가장 간단한 구조를 가진 에틸렌계 탄화수소의 하나이며" +
                    "상온에서는 무색의 기체상태로 존재한다. 용도는 가스 절단 및 용접 등에 활용된다.";
                break;
            case ATOM_TYPE.C2H6O_C2H5OH:
                info.name_ko = "에탄올";
                info.name_en = "ethanol";
                info.imagePath = imagePathSouce + "C2H6O";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "약간 특유한 냄새가 나는 휘발성, 인화성,무색 액체이며 술에도 들어가 있다. " +
                    "용도는 살균제 및 소독제, 해독제로 활용된다.";
                break;
            case ATOM_TYPE.C2H6O_CH3OCH3:
                
                break;
            case ATOM_TYPE.C6H6:
                info.name_ko = "벤젠";
                info.name_en = "benzene";
                info.imagePath = imagePathSouce + "C6H6";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "평면 정육각형의 고리구조를 가졌으며 무색이고, " +
                    "발암 물질로도 알려져 있다. 용도는 플라스틱,염료, 향료, 폭약 등의 원료로 활용되고 있다.";
                break;
            case ATOM_TYPE.CH2O:
                info.name_ko = "폼알데하이드";
                info.name_en = "formaldehyde";
                info.imagePath = imagePathSouce + "CH2O";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "자극적인 냄새가 나고, 무색이며 분자 구조는 알데하이드 중에서 유일한 대칭적 구조이다. " +
                    "용도는 플라스틱이나 가구용 접착제의 원료, 접착제, 도로의 성분으로 활용된다.";
                break;
            case ATOM_TYPE.CH3COOH:
                info.name_ko = "아세트산";
                info.name_en = "acetic acid";
                info.imagePath = imagePathSouce + "CH3COOH";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "상온에서는 무색의 자극성 강한 냄새를 가진 신맛이 있는 액체로 존재하며 식초에도 들어가 있다. " +
                    "용도는 무수 아세트산, 아세톤, 아세트산 에스테르류 등의 원료로 활용된다.";
                break;
            case ATOM_TYPE.CH3OH:
                info.name_ko = "메탄올";
                info.name_en = "methanol";
                info.imagePath = imagePathSouce + "CH3OH";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "가장 간단한 알코올 화합물로 무색의 휘발성, 가연성, 유독성 액체이다. " +
                    "용도는 폐수처리, 바이오 디젤 생산, 석유, 화학에 활용된다.";
                break;
            case ATOM_TYPE.CH4:
                info.name_ko = "메테인";
                info.name_en = "methane";
                info.imagePath = imagePathSouce + "CH4";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "실온에서 무색의 기체이다. " +
                    "온실효과의 원인이기도 하며 용도는 천연 가스의 주성분으로, 연료로 많이 활용된다";
                break;
            case ATOM_TYPE.CL2:
                info.name_ko = "염소 분자";
                info.name_en = "molecular chlorine";
                info.imagePath = imagePathSouce + "Cl2";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "상온에서 황록색의 자극적인 냄새가 나는 유독기체이다. " +
                    "용도는 표백제, 수영장 소독으로 활용된다.";
                break;
            case ATOM_TYPE.CO2:
                info.name_ko = "이산화탄소";
                info.name_en = "carbon dioxide";
                info.imagePath = imagePathSouce + "CO2";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "실온에서 기체로 존재하며 생물에게 있어 무독성이다. " +
                    "용도는 고체상태의 드라이아이스로 활용된다.";
                break;
            case ATOM_TYPE.H2:
                info.name_ko = "수소 분자";
                info.name_en = "molecular hydrogen";
                info.imagePath = imagePathSouce + "H2";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "상온에서 무색 무취의 기체이다 용도는 로켓의 연료, " +
                    "암모니아 합성의 원료, 연료전지로 활용된다.";
                break;
            case ATOM_TYPE.H2O:
                info.name_ko = "물";
                info.name_en = "water";
                info.imagePath = imagePathSouce + "H2O";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "실온에서 무색 액체 상태이며 기본적으로 투명하다. " +
                    "용도는 생수, 얼음으로 활용된다";
                break;
            case ATOM_TYPE.H2O2:
                info.name_ko = "과산화수소수";
                info.name_en = "hydrogen peroxide";
                info.imagePath = imagePathSouce + "H2O2";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "색깔이 없고 쓴맛을 가진 액체이며 간단한 형태의 과산화물이다. " +
                    "용도는 로켓 추진 연료, 화장품, 의약품을 만들 때 활용된다. ";
                break;
            case ATOM_TYPE.HCL:
                info.name_ko = "염화 수소";
                info.name_en = "hydrogen chloride";
                info.imagePath = imagePathSouce + "HCl";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "상온에서 무색의 유독한 기체이다. " +
                    "강산이며 용도는 찌든 때 제거에 쓰이거나 철의 녹을 없애는데 활용된다";
                break;
            case ATOM_TYPE.HCN:
                info.name_ko = "사이안화 수소";
                info.name_en = "hydrogen cyanide";
                info.imagePath = imagePathSouce + "HCN";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "실온에서 무색의 액체이며 아몬드 냄새가 난다. " +
                    "용도는 군사용 독가스, 독극물로 활용된다.";
                break;
            case ATOM_TYPE.N2:
                info.name_ko = "질소 분자";
                info.name_en = "molecular nitrogen";
                info.imagePath = imagePathSouce + "N2";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "냄새, 색깔이 없는 기체의 형태로 존재한다. " +
                    "용도는 암모니아 합성에 많이 활용된다.";
                break;
            case ATOM_TYPE.NH3:
                info.name_ko = "암모니아";
                info.name_en = "ammonia";
                info.imagePath = imagePathSouce + "NH3";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "실온에서 무색 기체이며 자극적인 냄새가 난다. " +
                    "용도는 농약 비료로 활용된다.";
                break;
            case ATOM_TYPE.O2:
                info.name_ko = "산소 분자";
                info.name_en = "molecular oxygen";
                info.imagePath = imagePathSouce + "O2";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "상온에서 무색 무취의 기체이지만 액체 및 고체에서는 담청색이며 인간의 호흡에 필수적이다. " +
                    "용도는 제철소, 철 구조물 용접에 활용된다.";
                break;
            case ATOM_TYPE.O3:
                info.name_ko = "오존";
                info.name_en = "ozone";
                info.imagePath = imagePathSouce + "O3";
                info.prefabsPath = AtomType2PrefabsPath(type);
                info.exp = "지구 대기중에 오존층을 보호한다. " +
                    "상온 대기압에서 푸른빛의 기체이며 용도는 하수의 살균, 악취제거로 활용된다.";
                break;
        }

        return info;
    }

    public static AtomInfo type2AtomInfo(ATOM_TYPE type) {

        var info = new AtomInfo();

        return info;
    }

    public static string AtomType2PrefabsPath(ATOM_TYPE type) {

        string prePath = "Atom/AtomPrefabs/";
        string name = "";

        switch (type) {
            case ATOM_TYPE.NONE:
                break;
            case ATOM_TYPE.A_CARBON:
                name = "a_carbon";
                break;
            case ATOM_TYPE.A_CHLORINE:
                name = "a_chlorine";
                break;
            case ATOM_TYPE.A_HELIUM:
                name = "a_helium";
                break;
            case ATOM_TYPE.A_HYDROGEN:
                name = "a_hydrogen";
                break;
            case ATOM_TYPE.A_NEON:
                name = "a_neon";
                break;
            case ATOM_TYPE.A_NITROGEN:
                name = "a_nitrogen";
                break;
            case ATOM_TYPE.A_OXYGEN:
                name = "a_oxygen";
                break;
            case ATOM_TYPE.C2H2:
                name = "m_c2h2";
                break;
            case ATOM_TYPE.C2H4:
                name = "m_c2h4";
                break;
            case ATOM_TYPE.C2H6O_C2H5OH:
                name = "m_c2h6o(c2h5oh)";
                break;
            case ATOM_TYPE.C2H6O_CH3OCH3:
                name = "m_c2h6o(ch3och3)";
                break;
            case ATOM_TYPE.C6H6:
                name = "m_c6h6";
                break;
            case ATOM_TYPE.CH2O:
                name = "m_ch2o";
                break;
            case ATOM_TYPE.CH3COOH:
                name = "m_ch3cooh";
                break;
            case ATOM_TYPE.CH3OH:
                name = "m_ch3oh";
                break;
            case ATOM_TYPE.CH4:
                name = "m_ch4";
                break;
            case ATOM_TYPE.CL2:
                name = "m_cl2";
                break;
            case ATOM_TYPE.CO2:
                name = "m_co2";
                break;
            case ATOM_TYPE.H2:
                name = "m_h2";
                break;
            case ATOM_TYPE.H2O:
                name = "m_h2o";
                break;
            case ATOM_TYPE.H2O2:
                name = "m_h2o2";
                break;
            case ATOM_TYPE.HCL:
                name = "a_carbon";
                break;
            case ATOM_TYPE.HCN:
                name = "m_hcn";
                break;
            case ATOM_TYPE.N2:
                name = "m_n2";
                break;
            case ATOM_TYPE.NH3:
                name = "m_nh3";
                break;
            case ATOM_TYPE.O2:
                name = "m_o2";
                break;
            case ATOM_TYPE.O3:
                name = "m_o3";
                break;
        }

        return prePath + name;
    }

    
}
