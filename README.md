# DLLInject 💉

https://github.com/LUCKYONE-CC/DLLInject/assets/112805534/c4549bc3-df66-4e22-8e8f-f054ff2e5751

## Overview

DLLInject is a simple command-line tool written in C# that allows you to inject a dynamic-link library (DLL) into a target process. This can be useful for various purposes, including debugging and extending the functionality of a running application.
## Features

- **Interactive Command Line**: DLLInject provides an interactive command-line interface where you can enter commands to perform various operations.

- **Command List**:
    - `exit`: Exit the application.
    - `getallprocesses`: Display a list of all processes.
    - `inject`: Inject a DLL into a specified process. 💉

- **DLL Injection**: The `inject` command allows you to inject a DLL into a target process using the process ID (PID) and the path to the DLL.

## Usage

**1. Clone the repository**
```
git clone https://github.com/your-username/DLLInject.git
```
**2. Build the project using your preferred C# development environment.**
**3. Run the executable:**
```bash
cd DLLInject
dotnet run
```
**4. Enter commands at the prompt. For example:**
```bash
> getallprocesses
> inject -pid 1234 -dllpath C:\Path\To\Your\Injected.dll
```

## How It Works
The `DLLInject` project consists of two main components:

**Command Line Interface (CLI)**: The `Program` class handles the interactive command-line interface, allowing users to input commands and interact with the application.

**Injector**: The `Injector` class contains methods for injecting a DLL into a target process. It utilizes Windows API functions from `kernel32.dll` for memory allocation, process handling, and thread creation.

## Build and Run

Ensure you have the .NET SDK installed. Build and run the project using the following commands:
```bash
dotnet build
dotnet run
```

## Disclaimer
This tool is provided for educational and research purposes only. Misuse of this tool for malicious purposes is strictly prohibited.
