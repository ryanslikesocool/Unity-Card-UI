# Unity Card UI
Some basic card style UI elements in Unity 2018.1.1f1

#### 2D Card stack
This is a basic card stack, similar to the app switcher on iOS 9+.  The contents can be changed and it's possible to turn cards in the stack into 2D expanding cards.
![Alt Text](https://github.com/ryanslikesocool/Unity-Card-UI/blob/master/Card%20Stack.gif)

#### 2D Falling popups
These popups are heavily inspired by Ryan McLeod's "Blackbox" game.  It's available for free on the iOS App Store.  These popups are an attempt to copy the popups in his game.
![Alt Text](https://github.com/ryanslikesocool/Unity-Card-UI/blob/master/Falling%20Popups.gif)

#### 2D Expanding Card
The 2D expanding cards are nowhere near as cool as the one that's up next.  Click on it and it expands into an (almost) full sized page.  Click the red circle in the top right of the page to shrink it back into a card.
![Alt Text](https://github.com/ryanslikesocool/Unity-Card-UI/blob/master/Expanding%20Card.gif)

#### 3D Custom Superellipses
This one is my personal favorite.  It unfortunately has to use some outside scripts from the Unify Community Wiki, but it's totally worth it.  It takes a bunch of points from one quadrant of a superellipse and turns it into a mesh that can be used and changed at runtime.  You can change the roundness (or "superness" if you want to sound cool) of the corners.  You can also change the x and y extents and the level of detail of the quadrant, but that's not nearly as fun ;) .  It's a bit messy to get set up with the interactive part of the UI (and unfortunately it's only visible at runtime) but it's still pretty neat in my opinion.
![Alt Text](https://github.com/ryanslikesocool/Unity-Card-UI/blob/master/Custom%20Superellipses.gif)

## Other Stuff
Drag and drop the contents of the Assets folder anywhere into your project's Assets folder.  Most of the info you need is on the cards in the scenes.  The code is decently commented as well.  If you have any other questions or suggestions, feel free to create an issue.

## Credits
#### Unify Community Wiki
Triangulator.cs, PolygonTester.cs (which I renamed to MeshCreator.cs)
#### Ryan McLeod
Inspiration
#### My dad
Some math help
#### me
Most everything else