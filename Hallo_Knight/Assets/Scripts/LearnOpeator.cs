using UnityEngine;

//認識運算子
//1.數學運算子
public class LearnOpeator : MonoBehaviour
{
    
    int a = 10;
    int b = 3;
    int c = 7;
    public int hp = 100;

    public float scoreA = 99;
    public float scoreB = 1;

    public int health = 50;
    public int key = 1;
    public int chess = 5;
    public int diamond = 0;

    void Start()
    {
        #region 數學運算子
        print(a + b); //13
       print(a - b); //7
       print(a * b); //30 
       print(a / b); //3
       print(a % b); //1

        c = c + 1; // = 指定符號 :右邊先運算完再給左邊
        c++;       //上面這一行的簡寫  兩者是一樣的算式
        //print("c運算完後的結果:" + c);
        //--c;
        //--c;
        //--c;
        //print("c運算完後的結果:" + c);

        //指定運算 - 適用加減乘除餘
        //例子 扣血-13
        
        hp = hp - 13;  //87
        hp -= 13;      //74

        //例子 補血+20
        hp += 20;      //94
        hp /= 2;       //47
        #endregion

        #region 比較運算子
        // > < >= <= == !=
        //使用比較運算子的結果 都是布林值
        // 比較正確結果為true 否則為false
        print("99等於1=" + (scoreA == scoreB));
        print("99不等於1=" + (scoreA !=scoreB));
        #endregion

        #region 邏輯運算子
        print("邏輯運算子");
        // 比較兩筆布林值的資料
        print("並且");
        // 並且 &&
        // 只要有一個布林為false 結果便會變成false
        print(true && true);       //ture
        print(true && false);      //false             
        print(false && true);      //false 
        print(false && false);     //false

        print("或者");
        //或者 ||
        // 只要有一個布林為true 結果便會變成true
        print(true || true);        //true
        print(true || false);       //true
        print(false || true);       //true
        print(false || false);      //false

        //過關條件= 血量大於0 而且鑰匙要大於1
        print("是否有過關:" + (health > 0 && key == 1));
        //過關條件= 箱子超過五個 或者拿到兩個以上的鑽石
        print("是否有過關:" + (chess >= 5 || diamond >= 2));

        //相反!
        print(!true);
        print(!false);

        #endregion
    }

}
