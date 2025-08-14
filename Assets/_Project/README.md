# Notes
- I rebuilt the StateMachine and State classes first as abstract, non-player related classes, then extended them to create the PlayerStateMachine and PlayerState classes.
- I split the gravity logic to a separate method in PlayerMovement to keep the player object falling even if the player is not moving.
- I relied on abstract base classes to implement the PlayerAbility class, but I'm intrigued by the idea of using ScriptableObjects for abilities, would love to see how that could work.
- I added a simple VisualHandler class to manage the invisibility visual effect, which could be expanded to handle more complex visual effects in the future.