# Flappy Bird Clone 

#### Unity version -> 2021.1.0f1 older versions shouldnt be a problem


StartController -> Listens Taps on play button then changes scene

ObstacleManager -> creates obstacles

ObstacleController -> Moves obstacles towards player

PlayerController -> Player Jumps between obstacles, checks collision if its score increases it, if its deadly activates GameOver sprite changes state, checks with isTrigger

LevelManager -> waits for tap on endgame, then reloads startscene

Needs Polishing with end game and performance upgrade by moving digit creation to text or object pooling

## Usage

#### GameManager
Used For Managing GameStates. Use  for state registration then define a void function with enum GameState's name.

```c#
# GameStateEvents add or remove new states
public enum GameState {PREP,MID,END} 

# registers class to GameStateEvents 
GameManager.Instance.AddGameStateListener(this) 

# runs on PREP state, for another define function with enum GameState's name
void PREP(){} 
```

#### InputManager
 
Detection of Swipe, Slide, Tap, Double Tap or Tapping on objects with collider.

```c#
# tap registration
InputManager.Instance.RegisterTap(UnityAction<Tap> tapFunc) 

# tap function 
void tapFunc(Tap tap){} 
```

Same with swipe and slide.
 
RegisterSlide => UnityAction<Slide>

RegisterSwipe => UnityAction<Swipe>

#### AbstractController

Abstract Generic Template Class for Future Controller Classes. It connects Controller to View and Model 
```c#
# usage
public class PlayerController : AbstractController<PlayerModel,PlayerView>

# after extending Abstract class View can be accessed via View. or Model can be accessed via Model.
View.Rotate(Quaternion.Euler(0f, 0f, rotate));
```

### AbstractView

Abstract Generic Template Class for Future View Classes. It connects View to Controller
```c#
# usage
public class PlayerView : AbstractView<PlayerController>

# public class for controller to access
public void Rotate(Quaternion quaternion)
{
   transform.rotation = quaternion;
}


# after extending Abstract class Controller can be accessed via Controller.
Controller.OnCollision(collision);
```