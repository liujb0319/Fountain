# How to build Fountain from the command line
Fountain uses [Cake](cakebuild.net) for the easy command-line building. Currently, Cake is configured to compile for Release, so the compiled version of Fountain can be found in **./Fountain/bin/Release/**

## On Windows
### From cmd:
```
powershell ./build.ps1
```
### From bash:
```
powershell ./build.ps1
```

### From PowerShell:
```
./build.ps1
```

## On Linux / Mac OS
```
./build.sh
```

# Known Issues/To Do List
* Add existing map underlay/overlay to make tracing easier.