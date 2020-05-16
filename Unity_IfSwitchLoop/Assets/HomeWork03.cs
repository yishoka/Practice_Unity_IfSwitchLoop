using UnityEngine;
using UnityEngine.UI;



public class HomeWork03 : MonoBehaviour
{
    // 定義拉霸欄位
    public Slider HomeWorkSlider1;

    // 定義封裝欄位與讀寫屬性：血量
    private int hp;
    public int Hp { get => hp; set => hp = value; }

    // 建立Text文字
    public Text hptext;
    public Text itemtext;

    // 建立InputField輸入欄位
    public InputField item;

    // 建立地板物件
    public GameObject cube;

    private void Start()
    {
        // 設定拉霸最大、最小值，並設定成開始時血量為100
        HomeWorkSlider1.minValue = 0;
        HomeWorkSlider1.maxValue = 100;
        HomeWorkSlider1.value = 100;
    }

    public void Update()
    {
        // 讀取拉霸的值為血量（讀取時轉成int）
        hp = (int)HomeWorkSlider1.value;
        // 設定判定
        // 三元運算子寫法：hptext.text = hp >= 70 ? "安全" : hp >= 30 ? "警告" : "危險";
        if (hp >= 70)
        {
            hptext.text = "安全";
        }
        else if (hp >= 30)
        {
            hptext.text = "警告";
        }
        else
        {
            hptext.text = "危險";
        }

        // 讀取輸入欄位的文字後，使用三元運算子判斷應該顯示何種道具提示
        itemtext.text = item.text == "紅水" ? "恢復血量" : item.text == "藍水" ? "恢復魔力" : "輸入道具名稱";
    }

    // 創建製作地板的method
    private void CreateFloor(int width, int length)
    {
        // 巢狀迴圈
        // 注意初始值名稱不能相同
        for (int j = 0; j <= width; j++)
        {
            for (int i = 0 ; i <= (j*2); i++)
            {
                // API 實例化(生成)
                // 生成(物件，座標，角度)
                // Vector3 三維向量(保存三個浮點數)
                // Quaternion 角度
                // Quaternion.identity 零角度
                // Quaternion.Euler(x, y, z) 歐拉角度 = 0-360
                Instantiate(cube, new Vector3(j * 2, i * 2, 0), Quaternion.Euler(270, 0, 0));
            }
        }
    }

    private void Awake()
    {
        CreateFloor(10,10);
    }
}
