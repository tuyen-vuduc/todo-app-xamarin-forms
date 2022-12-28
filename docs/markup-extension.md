
# Custom Markup Extensions

## EdgetInsetsExtension
A markup extension allows us to easy and meaningfully define a margin, a padding in XAML.

E.g.
```xml
// All edge spacings are the same
<View 
  Margin="{app:EdgetInsets 
    All={x:Static app:Dimens.SpacingNormal}}" />

// Top and bottom edge spacings are the same
<View 
  Margin="{app:EdgetInsets 
    Vertical={x:Static app:Dimens.SpacingNormal}}" />

// Left and right edge spacings are the same
<View 
  Margin="{app:EdgetInsets 
    Horizontal={x:Static app:Dimens.SpacingNormal}}" />

// Each edge spacing is different
<View 
  Margin="{app:EdgetInsets 
    Top={x:Static app:Dimens.SpacingNormal},
    Right={x:Static app:Dimens.SpacingLarge},
    Bottom={x:Static app:Dimens.SpacingSmall},
    Left={x:Static app:Dimens.SpacingExtra}}" />
```

## BindingContextExtension
A markup extension allows us to wire up view model for a view in which view model will be constructed using DI from DryIoC.

E.g.
```xml
<app:BasePage
    [...]
    xmlns:app="clr-namespace:TodoApp"
    BindingContext="{app:BindingContext {x:Type app:TodosPageViewModel}}">
```
