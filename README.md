DSE ODS .NET Library
--------------------

.NET library for communicating with, and decoding measurement telegrams from Optical Displacement Sensors (ODS) made by [Danish Sensor Engineering](https://www.danish-sensor-engineering.com) (DSE).



## Build & Release


```shell
dotnet build --configuration Releas
dotnet pack --configuration Release
```

Publish to Github (not working yet)

```shell
dotnet nuget push "bin/Release/DSE.Library.ODS.0.0.1.nupkg" --source "github"
```
