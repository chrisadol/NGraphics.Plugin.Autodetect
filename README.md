# NGraphics.Plugin.Autodetect
NGraphics.Plugin.Autodetect is to enable autodection of the platform from a PCL project (i.e. to enable NGraphics usage directly within a Xamarin Forms Portable/PCL project).

#### Disclaimer
This plugin is NOT in any way affiliated with the actual [NGraphics](https://github.com/praeclarum/NGraphics/) creators, so if this plugin does not work then it is not their fault!

## Installation
You can [install the NGraphics.Plugin.Autodetect from nuget](https://www.nuget.org/packages/NGraphics.Plugin.Autodetect). 

Ensure you install it in all projects where you want the code to work, even though you will be writing code in the main Xamarin.Forms app.

## Usage

The only feature in NGrpahics.Plugin.Autodetect is `AutodetectNGraphicsPlatform.AutodetectCurrent` which can be called directly from within Xamarin Forms  Portable app code.

In your Xamarin Forms Portable app add the following `using` statements:
```csharp
using NGraphics;
using NGraphics.Plugin.Autodetect;
```
Next, again in your Xamarin Forms Portable app, call `AutodetectNGraphicsPlatform.AutodetectCurrent` as follows:
```csharp
var size = new NGraphics.Size(1000, 1000);
var canvas = AutodetectNGraphicsPlatform.AutodetectCurrent.CreateImageCanvas(size, scale: 2);

var skyBrush = new LinearGradientBrush(Point.Zero, Point.OneY, Colors.Blue, Colors.White);
canvas.FillRectangle(new Rect(canvas.Size), skyBrush);
//refer to NGraphics documentation on how to use NGraphics itself
canvas.GetImage().SaveAsPng(GetPath("Example1.png"));
```

Note that the actual [NGraphics documentation can be found here](https://github.com/praeclarum/NGraphics/blob/master/README.md).

