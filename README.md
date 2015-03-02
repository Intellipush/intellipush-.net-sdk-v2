Intellipush SDK for .NET
====================

This repository contains the open source .NET SDK that allows you to access Intellipush from your desired .NET application.

Usage with C#
-----

Specify the APPID and API_SECRET:
```csharp
IntellipushConfig.APPID = "yyyyyyy";
IntellipushConfig.API_SECRET = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
```

Create a simple SMS:
```charp
Sms sms = new Sms("Hello World", new PhoneNumber("0047", "12345678"));
string response = sms.Create();
```

Create a SMS to multiple receivers:
```csharp
List<PhoneNumber> receivers = new List<PhoneNumber>();
receivers.Add(new PhoneNumber("0047", "1234567"));
receivers.Add(new PhoneNumber("0047", "2345671"));

sms = new Sms();
sms.Receivers(receivers);
sms.TextMessage = "Hello World!";
sms.When(DateTime.Now.AddMinutes(20));

response = sms.Create();
```

[Intellipush C# SDK documentation ](https://www.intellipush.com/documentation/.net-sdk)


Sign up
-----
[Intellipush.com](https://www.intellipush.com)


Enjoy our service!

/Intellipush