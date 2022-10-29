# System.Extended

## Linq
Methods: ```JoinString, Shuffle, IsEmptyOrNull, IsEmpty, Pipe, ToEnumerable, ForEach```

## Byte
Methods: ```ConvertToBase64, ToString, GetHash```

## String
Methods: ```IsEmpty, IsMatch, ToBytes, GetHash, GetStringHash, FromBase64, FromBase64String```

## ExConsole
```C#
int readInt = ExConsole.ReadLine<int>("Enter int value: ");
```
```C#
var readInt = ExConsole.ReadLine<int>(x => int.TryParse(x, out _), x => Convert.ToInt32(x), "Enter int value: ");
```

## IniManager
```C#
IniManager ini = new IniManager(@"C:\main.ini");
var port = ini.Read("Connection", "Port");
ini.Write("Connection", "Port", "1900");
```

# Object replacing

```C#
class Aggregate
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class First
{
    public int Id { get; set; }
}

class Second
{
    public string Name { get; set; }
}

Aggregate aggregate = new Aggregate();
First first = new First { Id = 500 };
Second second = new Second { Name = "Git" };

aggregate.ReplaceBy(first); //aggregate.Id = 500
aggregate.ReplaceBy(second); //aggregate.Name = "Git"
Aggregate newAggregate = new Aggregate();
newAggregate.ReplaceBy(aggregate); //Id = 500, Name = "Git"
```
