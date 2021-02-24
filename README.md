# xamarin-android-practice
Practice code for Xamarin Android. 
# Phoneword
An application that translates an alphanumeric phone number into a numeric phone number

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
	- Override the `OnViewModelSet()`, `SetContentview(Resource.Layout.TipView)
	- Create `Resources/layout/TipView.xml`, design the UI
3. Run

# References
- [Setup and Installation](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/)
- [How to build the app](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android/hello-android-quickstart?pivots=windows)
- [Project structure explaination](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android/hello-android-deepdive?pivots=windows)
- [How to read Assets](https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/resources-in-android/android-assets?tabs=windows)
- [C# Delegates](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates)
- [C# Delegates Examples](https://www.tutorialspoint.com/csharp/csharp_delegates.htm)
- [Activity Lifecycle](https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/activity-lifecycle)
- [Add more screens to your app](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android-multiscreen/)
- [See more about the current code](https://docs.microsoft.com/en-us/xamarin/android/get-started/hello-android-multiscreen/hello-android-multiscreen-deepdive)
