# FlagConsole

## Overview

FlagConsole is a library for .NET, written in C#, that helps to build text-based console application interfaces. 
It provides controls like panel, textfield, list view, menu and label. It also offers drawing capabilitys for rectangles, lines and ellipses/circles.

## NuGet

FlagConsole is available via NuGet!
http://nuget.org/List/Packages/FlagConsole

## Features

FlagConsole tries to make everything as simple as possible and offers the following features:

- **Control:**
The control class is the base class for all other controls. It is extendable to create custom controls.

- **Label:**
A label can have a text and wraps this text into its drawing area.

- **ListView:**
A list view can have multiple entries that are displayed among each other.

- **Menu:**
The menu control looks like a ListView, but lets the user navigate through the items with the keyboard and select an item when pressing the enter key.

- **Panel:**
A panel can contain multiple other controls that can be placed relative to the panel, so that not every control has to be manually arranged when changing the position.

- **Screen:**
The screen is the topmost control and is responsible for updating and drawing its child controls. Think of it as a `Form` in WinForms or `Window` in WPF.

- **TextBox:**
A textbox is a highlighted input field and lets the user type text and submit it by pressing the enter key. The maximum length of the text can be restricted.

- **Line:**
There are three line types: horizontal, vertical and generic. While the horizontal and vertical lines can be drawn very fast, the generic line is dynamic and can be drawn in every direction.

- **Rectangle:**
There is support for drawing filled and unfilled rectangles.

- **Ellipse and Circle:**
Ellipses and circels can easily be drawn. Support for filled ellipses and cricles will be added in the future.

## Demo application

The download section contains an demo application, that shows the FlagConsole library in action.

## Screenshots of the demo application

### The main menu

![](http://flagbug.github.com/flagconsole/mainmenu.jpg)

### A label

![](http://flagbug.github.com/flagconsole/label.jpg)

### A text box

![](http://flagbug.github.com/flagconsole/textbox.jpg)

### Rectangles

![](http://flagbug.github.com/flagconsole/rectangle.jpg)

### Lines

![](http://flagbug.github.com/flagconsole/line.jpg)

### Ellipses

![](http://flagbug.github.com/flagconsole/ellipse.jpg)