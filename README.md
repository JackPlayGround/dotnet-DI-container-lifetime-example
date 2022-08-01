# dotnet-DI-container-lifetime

A demo shows dotnet dependency injection lifetime in console applications. *MyMessage* is injected when *MyService* is being constructed. The liftime of *MyMessage* and *MyService* can be selected by numbers in the demo:

```
> dotnet restore
> dotnet run
Select a scope of "MyService": [1] Transient [2] Scoped [default] Singleton
>> 1
Select a scope of "MyMessage": [1] Transient [2] Scoped [default] Singleton
>> 2
Create Scope in Demo? [1] Yes [default] No
>> 1
=== Run Scope 1 ===
MyMessage: instance created.
MyService: instance created.
Write message...
MyService: instance created.
Write message...
=== Run Scope 2 ===
MyMessage: instance created.
MyService: instance created.
Write message...
MyService: instance created.
Write message...
```
