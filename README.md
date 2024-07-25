# Interview Portfolio : Skater Runner
您好，這份repository的檔案皆來自我創作的遊戲 Skater Runner    
我節選了幾個我認為寫得最好的腳本，希望能展現我的技術實力，感謝您撥冗閱讀。  
  
itch.io遊戲試玩連結 : 

## SaveSystemManager.cs & FileHandler.cs
  ### Feature
  - **Highly Secure** :  
    - Throws an exception when an error occurs during file reading or writing operations, informing the user immediately.
    - The `Load()` function will create a deep copy of the data to prevent it from being accidentally modified.
  - **Enhance flexibility** : The file handling logic can be easily replaced or upgraded without affecting other parts of the save system.
  - **Easy To Use** : Implemented with the Singleton pattern, it can be called from anywhere. Just one line of code :
    ```
    var data = SaveSystemManager.Instance.Load();
    ``` 
## IColletable.cs
  ### Overview
  `ICollectable` is an interface designed to standardize the behavior of collectible items in Skater Runner.   
  It defines a common set of methods that all collectible objects should implement, ensuring consistency across different types of collectibles.
  ### Method
  - **OnPickUp()** : This method should be implemented to define the behavior when the collectible item is picked up by the player.
  
