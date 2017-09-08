# Enable.Common.DataIntegrityException

A .NET exception type representing an attempt that has been made to compromise the integrity of application data.

[![Build status](https://ci.appveyor.com/api/projects/status/1ldv9h4uk93n1pnq?svg=true)](https://ci.appveyor.com/project/EnableSoftware/enable-common-dataintegrityexception)

## Usage

```csharp
throw new DataIntegrityException();
throw new DataIntegrityException("exception message");
throw new DataIntegrityException("exception message", wrappedException);
```
