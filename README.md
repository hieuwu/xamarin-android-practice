# xamarin-android-practice
Practice code for Xamarin Android. 
# Phoneword
An application that translates an alphanumeric phone number into a numeric phone number

**Objectives:**
- Get started in Xamarin.Android development
- Project structure
- Basic concepts such as Event handling and Activity Lifecycle

**Recap:**
1. Create Xamarin.Android project
2. Implement the UI
3. Handle event when click button and type in the Edittext
4. Add log statement to see the Activity state when configuration changes occur

**References:**
- [Setup and Installation](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/)
- [How to build the app](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android/hello-android-quickstart?pivots=windows)
- [Project structure explaination](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android/hello-android-deepdive?pivots=windows)
- [How to read Assets](https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/resources-in-android/android-assets?tabs=windows)
- [C# Delegates](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates)
- [C# Delegates Examples](https://www.tutorialspoint.com/csharp/csharp_delegates.htm)
- [Activity Lifecycle](https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/activity-lifecycle)
- [Add more screens to your app](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android-multiscreen/)
- [See more about the current code](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android-multiscreen/hello-android-multiscreen-deepdive)

# TipCalc
An application that convert the subtotal to the tip leave

**Objectives:**
- The general structure of MvvmCross applications
- Some of the code elements required in all MvvmCross applications
- Data-Binding

**Recap:**
1. Create core project
	- Create `ViewModels/TipViewModel.cs` extends `MvxViewModel` (this class contains the business logic and decide what to display)
	- Create `Services/ICalculationService.cs` interface
		+ Declare `TipAmount` function
	- Create `Services/CalculationService.cs` class
		+ Implement the `ICalculationService` and override `TipAmount` function
	- In the root project, create `App.cs` class extends `MvxApplication`
		+ Inside the Overrided `Initalize()`, register the `ICalculationSerivce` with `Mvx.RegisterTyp`e method (IoC:  Register `CalculationService` class to implement `ICalculationService` service)
		+ Register the `TipViewModel` with `RegisterNavigationSerivceAppStart` function (the viewmodel/view appears when the app starts)
2. Create Android project
	- Create `Setup` class extends `MvxAndroidSetup`
	- Add `TipCalc.Core` as References (*Right click on TipCalc.UI.Droid > Add > References > Projects > TipCalc.Core*)
	- Implement constructor with Context parameter and the base funtion
	- Override the `CreateApp()`, `return new App()`
	- Create `Views/TipView.` **Note:** Name of the view class must match the name of view model ex: TipViewModel - TipView
	- Override the `OnViewModelSet()`, `SetContentview(Resource.Layout.TipView`)
	- Create `Resources/layout/TipView.xml`, design the UI
3. Run

**References**
- [YouTube Tutorial](https://www.youtube.com/watch?v=qGup08cz7LM&list=PLUGZRUcMsHDSa8j2JcJECq7OuRj6vafRe&index=2)
- [Document Tutorial with in 5.6.3 version](https://github.com/MvvmCross/MvvmCross/tree/5.6.3/docs/_documentation/tipcalc-tutorial)
- [Dependency Injection](https://www.tutorialsteacher.com/ioc/dependency-injection)
- [Inversion of Control](https://www.tutorialsteacher.com/ioc/inversion-of-control)

# About MvvmCross

**What?**
A framework enables developers to create cross platform apps (Xamarin.Android, WPF).
**Why?**
- MVVM architecture pattern
- Navigation system
- Data Binding
- Platform specifics support
- Inversion of Control container and Dependency Injection engine
- Lots of plugins for common functionalities
- Unit test helpers

**Ingredients**
- The **Core**: contains ViewModel, Services, Models and business code
- The **UI**: contains the Views, platform specific code for intergrating with the **Core** apove

**Deep dive project structure**
- **The "Core" include:  **
	- An application object called `App.cs`
	- A custom `AppStart` object manages first navigation
	- ViewModels, decide the business logic inherit from `MvxViewModel`. Contain:
		- C# properties with raise changes
		- Commands
		- Private methods
	- Services, Models, Repositories,...
- **Platform projects:**
	- Native platform initialization code
	- `Setup.cs` class (optional)
	- `Views`: for presenting `ViewModels`
	- `ViewPresenters`: decides how `Views` show
	- Custom SDK code (controls, gestures, services,...)

- **Declare initialization with `Application` class in Android**

```java
namespace MyAwesomeApp.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<MvxAndroidSetup<App>, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
```

**How it works? When an MvvmCross app starts:**
1. Start up process fires
2. `Setup` is created
3. `Setup` initializes the framework:
	- `InitializePrimary`: runs on the main thread. Initializes IoC, Logging, other core part
	- `InitializeSecondary`: runs on the background. Constructs platform services like bindings, `App` class init. Registers Views/ViewModels lookups
4. When `App.Initialize` is called, the app will provide the `AppStart` object, responsible for the first navigation. The last step of `Setup` is calling `AppStart.Startup(object hint)`
5. `AppStart.Startup(object hint)` runs the first ViewModel/View

**Binding Modes:**

- **One-Way:** (Default)
	- Data goes from `ViewModel` to the `View`
	- The `View` will update automatically when data in `ViewModel` changes
	- *Use case:* to show data which is arriving from a dynamic source (sensor or network)

- **One-Way-To-Source:** (Rarely used)
	- Data goes from `View` to `ViewModel` (Opposite of the **One-Way**)
	- The `ViewModel` will update when data in the `View` changes
	- *Use case*: to collect new data from user, ex: User fill in a form
- **Two-Way:** (Commonly used)
	- Data is transfered in both directions
	- If `View` or `ViewModel` changes, the rest will update
	- *Use case:* edit a existing data, ex: Edit an existing form
- **One-Time:** (Not very commonly use)
	- Data goes from `ViewModel` to `View`
	- `View` does not monitor any change from `ViewModel`
	- Data on the `View` is set once when the binding source is set, only changes when the binding source is reset
	- `Use case`: for fields which can be changes but do not need to update after the first time set
	- Ex: use this mode when set static text from language

```diff
+ text in green
```
