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
The control class is the base class for all other controls. When extending, it also allows to create new controls.

- **Label:**
A can have a text and wraps this text into it's drawing area.

- **ListView:**
A list view can have multiple entries that are displayed in one row.

- **Menu:**
The menu control looks like a ListView, but lets the user navigate through the items with the keyboard and select one item when pressing the enter key.

- **Panel:**
On a panel can be placed various controls, that can be arranged relative to the position of the panel, so that not every control has to be manually arranged when changing the position.

- **Screen:**
The screen is the topmost control and is responsible for updating and drawing its child controls.

- **TextBox:**
A textbox is a highlighted input field and lets the user input text and submit this text when pressing the enter key. The length of the text can also be restricted.

- **Lines:**
There are various line types, horizontal, vertical and generic. While the horizontal and vertical lines can be drawn very fast, the generic line is more dynamic and can be drawn in every direction.

- **Rectangles:**
There is support for drawing filled and unfilled rectangles.

- **Ellipses and Circles:**
Ellipses and circels can easily be drawn. Support for filled ellipses and cricles will be added in the future.

## Demo application

In the download section is a demo application available, that shows the FlagConsole library in action.

## Screenshots of the demo application

### The main menu

![][1]

### A listview

![][2]

### A text box

![][3]

### Rectangles

![][4]

### Lines

![][5]

### Ellipses

![][6]

[1]: http://flagbug.github.com/flagconsole/mainmenu.jpg
[2]: http://flagbug.github.com/flagconsole/listview.jpg
[3]: http://flagbug.github.com/flagconsole/textbox.jpg
[4]: http://flagbug.github.com/flagconsole/rectangle.jpg
[5]: http://flagbug.github.com/flagconsole/line.jpg
[6]: http://flagbug.github.com/flagconsole/ellipse.jpg