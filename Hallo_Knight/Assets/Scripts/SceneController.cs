using UnityEngine;
using UnityEngine.SceneManagement; // 引用 場景管理 API
public class SceneController : MonoBehaviour
{
    // Unity 無法掛上腳本的兩大原因
    // 1.腳本內有紅色蚯蚓,任何一本
    // 2.類別與檔案名稱不同
    // 按鈕 On Click 設定點擊事件為此物件以及要呼叫的方法

    // Unity 按鈕如何與腳本溝通
    // 1. 公開的方法
    // 2. 需要實體物件掛此腳本

    /// <summary>
    /// 載入遊戲場景
    /// </summary>
    public void LoadGameScene()
    {
        //等兩秒後再載入場景
        //延遲呼叫(方法名稱,秒數)    方法必須要用字串方式放入
        //作用:等待指定時間後再呼叫此方法
        Invoke("DelayLoadGameScene", 2);
    }
    // 等待一段時間後再執行方法
    // Invoke 延遲呼叫
    /// <summary>
    /// 延遲載入場景
    /// </summary>
    private void DelayLoadGameScene()
    {
        // 場景管理. 載入場景("場景名稱");   這是載入指定的場景
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Invoke("DelayQuitGame",2);
    }

    /// <summary>
    /// 延遲離開遊戲
    /// </summary>
    private void DelayQuitGame()
    {
        Application.Quit();   // 應用程式.離開(); - 離開遊戲
        print("離開遊戲");     // Quit 在編輯器內不會執行
    }



}
