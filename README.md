# Unity Card Stack
iOS 9+ app switcher style cards in Unity.

# Basic stuff
A quick little thing I did in Unity 2018.1.1f1.  Feel free to do whatever as long as you don't claim the whole thing as your own.

# Usage and whatnot
On the Canvas object on the top level of the "Card UI" scene, there's a script called Card Controller.  That script has all of the card transform numbers and whatnot, mainly on lines 23 and 30.  Under the Canvas are a bunch of game object with numbers for names.  These are the cards.  You can add as many cards as Unity can handle to CardController.cards in the inspector.  The script will take care of the rest.  Make sure that in CardController.cards that the cards that you want in the back are up top and cards in the front are at the bottom.  It shouldn't be too hard to figure out but feel free to add an issue if you need help.
