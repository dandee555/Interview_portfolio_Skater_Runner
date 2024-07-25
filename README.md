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
  `DestructibleBase` is an abstract base class designed to implement core functionality for destructible objects in Cave Hero.   
  This class leverages the features of abstract classes to provide a universal framework for destructible objects.
  ### Feature
  - **Code Reusability** : `DestructibleBase` defines common properties and methods for destructible objects. Subclasses can directly inherit these common features, reducing code duplication.
  - **Improved Code Maintainability** : Centralizing common functionality makes modifications and extensions easier to manage.
  - **Polymorphism Promotion** : Allows handling different types of destructible objects through base class references.
  - **Increase Flexibility** :
    - The `GetHitOneTime()` method provides a common logic that defines the destruction process for all destructible objects.
    - The abstract methods `OnHit()` and `OnDestruction()` allow for customized behavior for each specific type of destructible object.
