# DevextremeToys

## Build Status

| Build | Status | Current Version |
| ------ | ------ | ------ |
| CI | [![.NET](https://github.com/AndreaPic/DevextremeToys/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/AndreaPic/DevextremeToys/actions/workflows/dotnet.yml) | N/A
| Packages | [![nuget-publish-tag](https://github.com/AndreaPic/DevextremeToys/actions/workflows/nuget-publish-on-tag.yml/badge.svg)](https://github.com/AndreaPic/DevextremeToys/actions/workflows/nuget-publish-on-tag.yml) | ![NuGet](https://img.shields.io/nuget/v/DevextremeToys)
| Packages | [![NUGET-PUBLISH-RELEASE](https://github.com/AndreaPic/DevextremeToys/actions/workflows/nuget-publish-on-release.yml/badge.svg)](https://github.com/AndreaPic/DevextremeToys/actions/workflows/nuget-publish-on-release.yml) | ![NuGet](https://img.shields.io/nuget/v/DevextremeToys)

## How to install

Follow instructions on [Nuget](https://www.nuget.org/packages/DevextremeToys/).

## About Extreme Developer's Toys

In dotnet framework there aren't some useful features.
These features are essential and every time we start a new project we need them so we look for them or rewrite them.
In this package there are some useful feature for every great developer.

- **ConcurrentList**
  - like List\<T\> but thread safe.
- **String Comparer Extensions**
  - With this extension you can use every string comparison but configured in the same way of your database.
- **String Extensions**
  - It adds some feature like ReplaceFirst or ReplaceLast.
- **URL base 64 encode & decode**
  - String extension to encode string to valid url encoded 64 and viceversa.
- **Reflection Extensions**
  - It adds features to all object like SetPropertyValue and GetPropertyValue.
- **Json Extensions**
  - It adds features to all objects like .ToJson() and .ToObject() for the string type.
- **Compression Extension**
  - It adds features to all object to zip an instance of object.
- **Serializer Extensions**
  - It adds features to all object to serialize them to and from byte[]
- **Cryptography Extensions**
  - It adds feature to encrypt and decrypt strings
- **List<> or IEnumerable<> Extensions**
  - It adds feature to List and IEnumerable such 'Split'
- **Visitor Extensions**
  - It adds visitor (graph explorer\object tree explorer) to traverse object graph\aggregate

## How to use

The first step is to install this package from [Nuget](https://www.nuget.org/packages/DevextremeToys/).

## Examples

### Comcurrent List

Add this using

```C#
using DevExtremeToys.Concurrent;
```

Now you can use ConcurrentList in a multi threading environment

```C#
ConcurrentList<int> list = new ConcurrentList<int>();
list.Add(i);

ConcurrentList<MyClass> list = new ConcurrentList<MyClass>();
list.Add(new MyClass() { Name = "Test"});
```

### String Comparer Extension

With this extension you can compare string with **Case Sensitive** and **Accent Sensitive** options.

Add this using

```C#
using DevExtremeToys.StringComparer;
```

Now you can compare strings with database rules

You can configure comparer rule once or use different configuration for every comparison.

In this example we use a global configuration

```C#
CompareSettings.Instance.GetSetting = () =>
{
    return new Settings()
    {
        CaseOption = CaseOptions.Insensitive,
        AccentOption = AccentOptions.Sensitive
    };
};

string s1 = "à1abbbcccaaabbbccc";
string s2 = "à1ABBBCCCAAABBBCCC";

Assert.True(s1.CompareToDevEx(s1) == 0);
```

In this example we use a specific configuration

```C#
var localSettings = new Settings()
{
    CaseOption = CaseOptions.Sensitive,
    AccentOption = AccentOptions.Sensitive
};
Assert.False(s1.CompareToDevEx(s2, localSettings) == 0);
```

### String Extensions

Add this using

```C#
using DevExtremeToys.Strings;
```

Now your strings have new features like ReplaceLast, ReplaceFirst

```C#
string s1 = "a1abbbcccaaabbbccc";
var r = s1.ReplaceLast("bbb", "ZZZ");
```

### URL base 64 encode & decode

Add this using

```C#
using DevExtremeToys.Url;
```

Now your strings have EncodeURL64 and DecodeURL64 methods 

```C#
string sourceString = "Dinanzi a me non fuor cose create \r\nse non etterne, e io etterno duro. \r\nLasciate ogne speranza, voi ch’intrate";
var encoded = sourceString.EncodeURL64();
var decoded = encoded.DecodeURL64();
```

### Reflection Extensions

Add this using

```C#
using DevExtremeToys.Reflection;
```

Now all objects have new features like:

- GetPropertyValue
- SetPropertyValue
- GetFieldValue
- SetFieldValue
- GetPropertyAttribute
- GetFiledAttribute

```C#
MyClass myClass = new MyClas();
myClass.SetPropertyValue(nameof(MyClas.Name), "My Name");
```

### Json Extensions

Add this using

```C#
using DevExtremeToys.JSon;
```

Now all objects have .ToJson() method and strings have .ToObject<>() method

```C#
TestClass myClass = new TestClass()
{
    Name = "My Name",
    Description = "My Description",
    Id = 10
};
var json = myClass.ToJSon();
TestClass deserialized = json.ToObject<TestClass>();
```

### Compression Extensions

Add this using

```C#
using DevExtremeToys.Compression;
```

Now all objects have .Zip() method and byte[] has .Unzip<>() method

```C#
MyClass myClass = new MyClass()
{
    Name = "My Name",
    Description = "My Description",
    Id = 10
};
var zip = myClass.Zip();
MyClass unZipped = zip.Unzip<MyClass>();
```

### Serializer Extensions

Add this using

```C#
using DevExtremeToys.Serialization;
```

Now all objects have .Zip() method and byte[] has .Unzip<>() method

```C#
MyClass myClass = new MyClass()
{
    Name = "My Name",
    Description = "My Description",
    Id = 10
};
var tmp = myClass.ToUTF8ByteArray();
MyClass deserialized = tmp.FromUF8ByteArray<MyClass>();
```

### Cryptography Extensions

Add this using

```C#
using DevExtremeToys.Strings;
```

Now all strings have .AesEncrypt method and .AesDecrypt methods

```C#
string key = "12345678901234567890123456789012";
string iv = "1234567890123456";
string plainText = "abcdefghijklmnopqrstuvwxyz1234567890";
string encrypted = plainText.AesEncrypt(key, iv);
string decrypted = encrypted.AesDecrypt(key, iv);
```

### List<> or IEnumerable<> Extensions

Add this using

```C#
using DevExtremeToys.List;
```

Now all List<> or IEnumerable<> have .Split method

```C#
IEnumerable<int> list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var subLists = list.Split(3);

List<int> list = new List<int>();
//...
var items = list.Split(3);
```

### Visitor Extensions

Add this using

```C#
using DevExtremeToys.Visitors;
```

Now all objects .Visit method

```C#
MyClassA a = new MyClassA();
//...
//fill object properties (collection, objects, internals...)
//...
a.Visit((nodeInfo) =>
{
    //nodeInfo.CurrentPath
    //nodeInfo.CurrentPropertyInfo
    //nodeInfo.CurrentInstance
    //nodeInfo.ParentInstance
    //nodeInfo.ParentNode
    //nodeInfo.PropertyName
    Debug.WriteLine(nodeInfo.CurrentPath);
});
```

## **... New features are coming soon ...**
