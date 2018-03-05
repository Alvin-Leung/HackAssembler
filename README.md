# HackAssembler

An assembler for the Hack computer architecture. Converts assembly language 
contained in an .asm file to machine code contained in a .hack file. The .hack 
file will be created in the folder of the .asm file and will take the name of
the .asm file. At assembly time, if there is a .hack file with the same filename
in the folder, it will be overwritten.

## Features

* Assembles assembly language to machine code for the Hack computer architecture
* Useable as a standalone application or through the command line
* Syntax verification
* Indicates line number of syntax violations

## Requirements

* Visual Studio 2017
* .NET Framework 4.6.1

## Build

Once you have checked out the code, open up the Visual Studio 2017 Developer 
Command Prompt and cd to the project directory. Build the project with the 
following command:

```
devenv HackAssembler.sln /build Release /project HackAssembler
\HackAssembler.csproj
```

Navigate to the HackAssembler\bin\Release directory to find the built 
executable.

## Using the HackAssembler

Once compiled, the HackAssembler can be run as a console application or directly 
from the command line. To use as a console application, run the 
HackAssembler.exe. You will be prompted for the filepath of the .asm file you 
wish to assemble. To use from the command line, open a console and enter the 
following command

```
HackAssembler <filepath>
```

Where filepath is the path to your .asm file. Example assembly code for the Hack computer architecture can be 
found at the [Nand2Tetris website](http://www.nand2tetris.org/software.php). 
Download the latest Nand2Tetris software suite and navigate to the \projects\06 
directory. Inside, there will be several small example programs written in 
assembly language. Use the HackAssembler to convert these .asm files into .hack 
files. The output .hack file from the HackAssembler can be loaded into the 
CPUEmulator, which is a tool that simulates the Hack computer architecture. The 
CPUEmulator can be found in the tools folder of the Nand2Tetris software suite, 
and can be started by running the CPUEmulator.bat file.
