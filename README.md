`cscmd`: The C# Command Line Execution Utility
=====

**Please note**: This project is archived. With modern .NET, you're much better off using `csi` as it is much more flexible and offers REPL capabilities. You can read more about `csi` in [this article](https://msdn.microsoft.com/en-us/magazine/mt614271.aspx) or [on the Roslyn wiki](https://github.com/dotnet/roslyn/wiki/Interactive-Window).

----------------

`cscmd` is a small tool for running small single-file C# programs on the command line as if they were scripts. It is useful for making one-off utility programs where you don't want to bother creating a whole Visual Studio solution and be throwing around built executable files.

I made this for my own use, but I hope you can find it useful too. It has been tested on Windows 8.1 as well as on Linux using Mono.

## Example Usage
Using the tool is very simple. Scripts are written exactly like any other simple C# command line program. There is a sample script, `test.cs` included that simply prints the contents of the first command line argument you pass to it. This file will be copied to the output directory upon build.

Executing `cscmd` with the example test script:

    cscmd test.cs "Hello, World :D"

Will print "Hello, World :D" to the command line.

## TODO
Since `cscmd` was something I quickly made to solve the problem I had at the time, it is not the most featureful program ever. Some things I would like to add to the program eventually are:

* Showing a "Just in Time Debugging" dialog when a script fails during execution. (And allowing Visual Studio to debug the script directly.)
* Allowing more references to be available to scripts (right now it just allows the ones Visual Studio 2012's Command Line Application template has by default.)
* Investigating [shebang](http://en.wikipedia.org/wiki/Shebang_\(Unix\)) support on Linux.
