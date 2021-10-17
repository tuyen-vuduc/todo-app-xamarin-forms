# Styles and Theming
Styles, Colors, Dimens are defined as static readonly fields, instead of using `ResourceDictionary`.
This approach helps us shorten the XAML files and easier to move to MAUI later on.

- Styles: Defines all common, shared Styles
- Colors: Defines all colors within the app
- Dimens: Defines all spacing, with, height and corner radius