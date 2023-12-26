# Project

##  1. <a name='Spec'></a>共用Spec

# 重點閱讀!!!
- [To Do](#ToDo)
- [開始遊戲流程](#)
*  [解鎖機制](#-1)
* [遊戲測試重點檢查部分](#-1)

##  2. <a name='StableBranchesbranch'></a>Stable Branches (不在這些做branch 做大改動)

- after_add_amiation -> lv 1,2 改善 + player animation 已merge
- all-lv-playable -> 各關已完整可玩,不再加大改動,美術不在這關改動

##  3. <a name='ToDo'></a>To Do

| 類型| 項目 | 負責人| 已完成? |
|---|------|---|---|
|  Game flow  |  關卡解鎖機制 (遊戲存檔)  |  家豐   |  NO!   | 
|  音效  |  遊戲bgm <br>（分關卡內和主畫面的背景音樂，每個章節不同，共需五首）  |  家豐   | NO!    | 
| 音效|    Player跳 | 家豐 |NO! |
| 音效|    重力切向上(可用像mario變大的音效?) | 家豐 |NO! |
| 音效|    重力切向下(用像mario變小的音效?)| 家豐 | NO!|
| 音效| 踫撞不能踫的物件音效    | 家豐 |NO! |
| 音效| 踫撞正常物件音效 (可有可無?)    | 家豐 | NO!|
| 音效|   Player死亡音效| 家豐 | NO!|
| 音效|   通關音效| 家豐 | NO!|
|  GUI  |   說明畫面設計美化  | 宇婕   |  NO!  | 
|  GUI  |  玩完整個遊戲的畫面(final 故事圖)   | 家豐    |  NO!  | 
|  關卡內容 | 教學關| 玟顥| | NO|
|  關卡內容 | lv1-2 杯下面需調| 玟顥| | NO|
|  GUI |   通關字句(加canvas, 過關時set active)  |  家豐  |  NO!  | 
|  debug  |  player飛出界的upper bound要調成腳一離開畫面就會死  |  玟顥  | NO!  |
|  遊戲美術  |  ch3 背景色??  |    |  NO  | 
|  debug |  player 被牆壁卡住  |            玟顥          |   done|
|  debug  |    player 靠牆時可跳 |           玟顥               | done |
|  debug  |  ch1 player 可穿杯子  |      玟顥           |  done |
|  遊戲美術  | 遊戲畫面邊框問題(改成令人不會誤會是牆)<br>(未想到如何改)   |     | done?   | 
|  遊戲美術  |  ch2 tilemap改圖   | 玟顥     | done   | 
|  遊戲美術  |  放player進遊戲 + 動畫  |  宇婕  | done   | 
|  遊戲美術  |  ch4 設計改動(仍未想到如何改)   |    |  done?(有空才再改) | 
| 關卡內容   |   Ch2-3內容需調  |  玟顥(應該是)  | done   | 
|   關卡內容    |   斟酌改動ch2-1(有空再調）  |   玟顥(應該是) | done   | 
|  GUI |   故事畫面切進關卡->要淡入淡出  |  家豐 |  done  | 
|  GUI  |   關卡內menu改造(改排版+加上下箭頭)  |  玟顥  |    | 
|    GUI   |  遊戲首頁設計   |    |  done  | 
|  GUI  |  重力為上/下的邊框配色   |    |  done  | 
| |     |  | |

##  4. <a name=''></a>開始遊戲流程
```
打開game -> menu頁 (3個按鈕)->按play
```
按play鍵之後流程
```
按play -> 檢查level saved

if(level saved ==0) (沒看過教學)
	按play btn -> 故事 ->help canvas (包含操作方式) -> 教學關 -> 選關卡page (只有lv1-1 unlocked)

if(level saved >0) (假設level saved ==n)
	按play btn ->  選關卡page (lv <=n unlocked )  
```

##  5. <a name='-1'></a>解鎖機制

menu + reset / clear memory 鍵 -> 按後清除saved level

存檔機制: 每次按save -> 覆蓋之前存的數值

##  6. <a name='-1'></a>遊戲測試重點檢查部分

- 地板底下有trap 的地方,player Q / jump 著陸時會否死(重點檢查lv 1-1)
- trap 檢查
 	-lv 2 重點檢查會否死, 應死不死, 不應死卻死了etc
	- lv3 重點檢查trap 會否離trap 很遠也觸法死亡 
- 各關所有可踩/不可踩地方測
- player動畫有沒有設成unscaled time
- 有沒有地方卡住player, e.x. 不會往下掉,又不能跳
- lv3, 4 的tilemap有否全部改composite collider
- 所有傳送門
- lv 3 block 內部死亡問題





##  7. <a name='Togglecount'></a>Toggle count
- control in Scripts->LevelSpec->LevelXX_Spec
- e.g. Level11_Spec->即ch1-1的spec, Level32_Spec->即ch3-2的spec

```
1-1: 3
1-2: 4
1-3: 3
2-1: 7
2-2: 3
2-3: 6
3-1: 1
3-2: 3(1)
3-3: 2
```

##  8. <a name='Function'></a>Function 架構

```
├─Player
   ├─GravityController.cs
   ├─PlayerMovement_NoAnimator.cs
   └─PlayerLifeControl.cs
   
├─SceneManager
   ├─SceneSpec.cs
   
├─GameManager
   ├─GameManager.cs
   
   
```

##  9. <a name='-1'></a>參考資料

###  9.1. <a name='HowtochangeGravityDirectionin1minuteQuickUnityTutorial'></a>How to change Gravity Direction in 1 minute | Quick Unity Tutorial
https://www.youtube.com/watch?v=KV8wNSo91bM

###  9.2. <a name='UnityScriptableObject'></a>Unity Scriptable Object
- 生一個物件template
- 用以快速生成擁有相同param 的物件
- !! Runtime 時改變的值會被存下來(可寫function 讓它不要存)

https://www.youtube.com/watch?v=aPXvoWVabPY&ab_channel=Brackeys

###  9.3. <a name='PausinggameinUnity'></a>Pausing game in Unity
https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
Time.timeScale = 0;

Time.deltaTime 會停止
update -> 會繼續被call
FixedUpdate -> 不會call

需在pause時播放的animation -> timescale set to unscaled time
