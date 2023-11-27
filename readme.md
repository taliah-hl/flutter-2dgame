# Project

## 共用Spec

### Player

- player size: TBC
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

### Function 架構

每個scene都需要:
- GameManager (Prefab)

每個關卡都需要:
- GameManager (Prefab)
- Player  (Prefab)
- 關卡內的UI

```
├─Player
   ├─GravityController
   ├─PlayerMovement_NoAnimator
   └─PlayerLifeControl
```
PlayerLifeControl
- 檢查player飛出界外,檢查player接觸trap / 關卡完成點

GameManager
- 裡面有跳至gameover / victory / main menu等function
- 裡面有遊戲暫停function (GameManager.pauseGame)


### Game Flow Control
- player object 每關重新create, 只有必要參數用DontDestroyOnLoad 傳

## 參考資料

### How to change Gravity Direction in 1 minute | Quick Unity Tutorial
https://www.youtube.com/watch?v=KV8wNSo91bM

### Unity Scriptable Object
- 生一個物件template
- 用以快速生成擁有相同param 的物件

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