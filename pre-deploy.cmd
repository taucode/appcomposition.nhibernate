dotnet restore

dotnet build TauCode.AppComposition.NHibernate.sln -c Debug
dotnet build TauCode.AppComposition.NHibernate.sln -c Release

dotnet test TauCode.AppComposition.NHibernate.sln -c Debug
dotnet test TauCode.AppComposition.NHibernate.sln -c Release

nuget pack nuget\TauCode.AppComposition.NHibernate.nuspec