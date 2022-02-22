# Landing Rocket
Landing Rocket exercise and tests

This repository contains a solution for an exercise and test methods for solution.

This is a .Net 5.0 Class Library. Used xUnit for testing.

## Excercise
Design a library that will help determine if rockets can land on a platform. 
Whenever rocket is getting back from the orbit, it needs to check every now and then if it's on 
a correct trajectory to safely land on a platform. Whole landing area (area that contains 
landing platform and surroundings) consists of multiple squares that set a 
perimeter/dimensions that can be described with coordinates (say x and y). Assuming that 
landing area has size of square 100x100 and landing platform has a size of a square 10x10 
and it's top left corner starts at a position 5,5 (please assume that position 0,0 is located at 
the top left corner of landing area and all positions are relative to it), library should work as 
follows:  
- if rocket asks for position 5,5 it replies `ok for landing`
- if rocket asks for position 16,15, it replies `out of platform`
- if the rocket asks for a position that has previously been checked by another rocket (only last check counts), it replies with `clash`
- if the rocket asks for a position that is located next to a position that has previously been checked by another rocket (say, previous rocket asked for position 7,7 and the rocket asks for 7,8 or 6,7 or 6,6), it replies with `clash`.

## Requirements

 - [.Net 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) 

## Usage

 - Clone repository
 - To run tests, use `dotnet test ./src/LandingRocket.Lib.Tests/LandingRocket.Lib.Tests.csproj` on terminal or run tests from Test Explorer in Visual Studio.

## Licence

MIT License

Copyright (c) 2022 Said Yeter

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.