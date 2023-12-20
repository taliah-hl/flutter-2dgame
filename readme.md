# Project

## 共用Spec

- [Project](#project)
  - [共用Spec](#共用spec)
    - [Player](#player)
    - [Scene](#scene)
  - [Function 架構](#function-架構)
    - [每個Script做什麼](#每個script做什麼)
    - [變數在哪裡](#變數在哪裡)
    - [Game Flow Control](#game-flow-control)
  - [參考資料](#參考資料)
    - [How to change Gravity Direction in 1 minute | Quick Unity Tutorial](#how-to-change-gravity-direction-in-1-minute--quick-unity-tutorial)
    - [Unity Scriptable Object](#unity-scriptable-object)
    - [Pausing game in Unity](#pausing-game-in-unity)

## Branch

- all-lv-playable -> 各關已完整可玩,不再加大改動,美術不在這關改動

## To Do

| 類型| 項目 | 負責人| 已完成? |
|---|------|---|---|
|  debug |  player 被牆壁卡住  |            玟顥          |   |
|  debug  |    player 靠牆時可跳 |           玟顥               |   |
|  debug  |  ch1 player 可穿杯子  |      玟顥           |   |
|  debug  |  player飛出界的upper bound要調成腳一離開畫面就會死  |  玟顥  |   |
|  遊戲美術  | 遊戲畫面邊框問題(改成令人不會誤會是牆)<br>(未想到如何改)   |     |    | 
|  遊戲美術  |  ch2 tilemap改圖   | 玟顥     |    | 
|  遊戲美術  |  放player進遊戲 + 動畫  |  宇婕  |    | 
|  遊戲美術  |  ch3 背景色   |    |    | 
|  遊戲美術  |  ch4 設計改動(仍未想到如何改)   |    |    | 
| 關卡內容   |   Ch2-3內容需調  |  玟顥(應該是)  |    | 
|   關卡內容    |   斟酌改動ch2-1(有空再調）  |   玟顥(應該是) |    | 
|  GUI |   故事畫面切進關卡->要淡入淡出  |  家豐 |    | 
|  GUI |   章節通關慶祝畫面  |  家豐+宇婕?  |    | 
|  GUI  |  玩完整個遊戲的畫面(final victory)   | 家豐+宇婕?    |    | 
|  GUI  |   關卡內menu改造(改排版+加上下箭頭)  |  玟顥  |    | 
|    GUI   |  遊戲首頁設計   |    |    | 
|  GUI  |   說明畫面設計美化  |    |    | 
|  GUI  |  重力為上/下的邊框配色   |    |    | 
|  Game flow  |  關卡解鎖機制 (遊戲存檔)<br>應該可以用把闖過的最高lv存進player preference做  |  家豐   |    | 
|  音效  |  遊戲bgm <br>（分關卡內和主畫面的背景音樂，每個章節不同，共需五首）  |  家豐   |    | 
| 音效|    Player跳 | 家豐 | |
| 音效|    重力切向上(可用像mario變大的音效?) | 家豐 | |
| 音效|    重力切向下(用像mario變小的音效?)| 家豐 | |
| 音效| 踫撞不能踫的物件音效    | 家豐 | |
| 音效| 踫撞正常物件音效 (可有可無?)    | 家豐 | |
| 音效|   Player死亡音效| 家豐 | |
| 音效|   通關音效| 家豐 | |
| |     |  | |


### Player

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

### Scene

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

## Toggle count
- control in Scripts->LevelSpec->LevelXX_Spec
- e.g. Level11_Spec->即ch1-1的spec, Level32_Spec->即ch3-2的spec

```
1-1: 3
1-2: 3
1-3: 3
2-1: 5
2-2: 3
2-3: 4
3-1: 1
3-2: 3(1)
3-3: 2
```

## Function 架構

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
### 每個Script做什麼

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

SceneSpec.cs
- load 該關卡的spec (目前只有max gravity toggle count)
- 提供 SceneSpec.MaxGravToggle (public)

### 變數在哪裡

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


### Game Flow Control
- player object 每關重新create, 只有必要參數用DontDestroyOnLoad 傳

## 參考資料

### How to change Gravity Direction in 1 minute | Quick Unity Tutorial
https://www.youtube.com/watch?v=KV8wNSo91bM

### Unity Scriptable Object
- 生一個物件template
- 用以快速生成擁有相同param 的物件
- !! Runtime 時改變的值會被存下來(可寫function 讓它不要存)

https://www.youtube.com/watch?v=aPXvoWVabPY&ab_channel=Brackeys

### Pausing game in Unity
https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
Time.timeScale = 0;

Time.deltaTime 會停止
update -> 會繼續被call
FixedUpdate -> 不會call

需在pause時播放的animation -> timescale set to unscaled time

hit pause
https://www.youtube.com/watch?v=C949ILsyywg
