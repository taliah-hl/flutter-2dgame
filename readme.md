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
###  6.1. <a name='GUIweneed'></a>GUI we need
1. main scene
   - 有play, 說明, menu
2. menu scene (有各個level 的按鍵)
   - 12 個按鍵 (4章->每要3關)
3. 大說明scene
   - 基本操作, 如何切重力, player踩到尖刺會死亡(因為每個章節都有因此擺在大說明，尖刺請放圖片)
4. 小故事scene (目前先把已經有的圖對應關卡放上去，先不管文本)
5. 章節說明*4
   - 有這章的機制
   - 有「開始遊戲」鍵
   - **章節說明的部分請截遊戲內場景object圖做說明**
   - chap1說明:
   - 	gravity object:關卡內存在受gravity所影響的物體，會隨gravity方向往上掉或往下掉
   - 	尖刺:碰觸會導致player死亡
     
   - chap2說明:
   - 	cloud:受到gravity影響的物體
   - 	platform1:會沿固定路線移動，只有上方可以踩
   - 	platform2:會沿固定路線移動，兩面皆可以踩
   - 	lava:由畫面上方流下，受gravity影響，player碰觸會死亡
     
   - chap3說明:
   - 	傳送門:player碰觸後會傳送到門的另一端，在經過使用後會進入2秒冷卻期，冷卻結束才能再次傳送
   - 	會虛實切換的東東:每次player跳躍會使其狀態虛實切換
     
   - chap4說明:
   - 	紅色地板:player踩中會導致中毒死亡
   - 	藍色小球:player碰觸到後可得一個持續10秒的保護罩，期間可以中毒的傷害
   - 	空中平台:player碰觸後經過2秒會變成gravity object受重力影響，紅色平台同樣會導致player中毒死亡
6. in-level GUI
   - static:
      - current level
      - 開說明的按鍵
   - 點說明是開的overlay GUI
7. 轉場動畫(算時間淡入淡出)
8. 死亡動畫-> 自動reload 該關
9. 闖完整章的scene

###  6.2. <a name='Player'></a>Player

- player size: x:0.89, y: 1.15
- player jump force: 12 
	- control at: player -> player movement script -> jumping force
- player velocity: 6 
	- control at: player -> player movement script -> movement speed
- player ->rigidbody ->gravity scale-> 3 
- 大概可跳起2.2 個grid
- 因player 本身有大小,這配搭剛好能跳上高度2個grid的東西
- 橫向大概可跳6格
- player die if position out of range: y<=-12 or y>=14

###  6.3. <a name='Scene'></a>Scene

- main camera -> Size: 10
- grid size: :(x,y)=(1,1)
- 場景直向有20格
- game view ->aspect: 1440*512 fixed resolution


以下為每個scene都需要相同的:
- GameManager
- Player 
- in-level UI

每個關卡都需要不同的(每個scene 獨立):

- SceneManager
- LevelSpec

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
   
   
├─in-level UI
    ├─GravityCntText
	     ├─GravityDisplayer
		      ├─GravityDisplay.cs
```
###  8.1. <a name='Script'></a>每個Script做什麼

PlayerMovement_NoAnimator.cs
- player 的左右跳
- 將來會用有animator的版本取代

GravityController.cs
- 控制gravity轉換
- 提供GravityController.GravToggleLeft (public)

PlayerLifeControl.cs
- 檢查player飛出界外,檢查player接觸trap / 關卡完成點

GameManager.cs
- 裡面有跳至gameover / victory / main menu等function
- 裡面有遊戲暫停function (GameManager.pauseGame)
- `GameOver()` in `GameManager.cs` -> 控制player死亡會的處理

SceneSpec.cs
- load 該關卡的spec (目前只有max gravity toggle count)
- 提供 SceneSpec.MaxGravToggle (public)

###  8.2. <a name='-1'></a>變數在哪裡

gravity toggle 剩餘次數 //public static, 即所有script 都可access
```
GravityController.GravToggleLeft  
```
gravity toggle max次數//public static
```
SceneSpec.MaxGravToggle
```

遊戲是否於暫定狀態 //public static
```
GameManager.IsGamePaused
```


###  8.3. <a name='GameFlowControl'></a>Game Flow Control
- player object 每關重新create, 只有必要參數用DontDestroyOnLoad 傳

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

hit pause
https://www.youtube.com/watch?v=C949ILsyywg
###  10. <a name='MainStory'></a>MainStory
第一幕:
睜開眼，你發現自己身處在一個廢棄的實驗室裡
在你眼前，一個藍綠色球狀生物靜靜地沉睡在圓柱館中
你擦拭了下圓柱管上布滿灰塵的標示牌，螢幕已經暗掉了，但你勉強能看清上面的訊息
上面寫著:
“ 實驗體編號: 110Z62DEA
實驗體物種: sd&#g%3*y^%$st(亂碼)(暫用名:Eva)
研究能力: 重力操作
原棲息地: w*&JAyg^&#$ctrj@5*%(亂碼)
實驗記錄: …… “
抬起頭，你對上了一雙懵懂的眼睛
那是Eva，他醒了，你喚醒了他…
==========================================
接下來你將協助Eva走出實驗室，找到他的同伴

