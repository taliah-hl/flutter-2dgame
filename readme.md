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


### Player

- player size: x: ~0.8-0.9, y: ~1-1.5
- player jump force: 16
	- control at: player -> player movement script -> jumping force
- player velocity: 10
	- control at: player -> player movement script -> movement speed
- player ->rigidbody ->gravity scale-> 5
- 大概可跳起2.2 個grid
- 因player 本身有大小,這配搭剛好跳不過高度2 grid 的trap
- player die if position out of range: y<=-12 or y>=14

### Scene

- main camera -> Size: 10
- grid size: :(x,y)=(1,1)
- 場景直向有20格


以下為每個scene都需要相同的:
- GameManager
- Player 
- 關卡內的UI (形式待定???)

每個關卡都需要不同的(每個scene 獨立):

- SceneManager
- LevelSpec

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
