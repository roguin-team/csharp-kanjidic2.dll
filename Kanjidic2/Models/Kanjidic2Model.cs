using LiteDB;

namespace Kanjidic2.Models;

public class Kanjidic2Model
{
    [BsonId]
    public ObjectId Id { get; set; } = default!;

    [BsonField("literal")]
    public string? Literal { get; set; }

    [BsonField("codepoints")]
    public List<Codepoint>? Codepoints { get; set; }

    [BsonField("radicals")]
    public List<Radical>? Radicals { get; set; }

    [BsonField("misc")]
    public Misc? Misc { get; set; }

    [BsonField("dictionaryReferences")]
    public List<DictionaryReference>? DictionaryReferences { get; set; }

    [BsonField("queryCodes")]
    public List<QueryCode>? QueryCodes { get; set; }

    [BsonField("readingMeaning")]
    public ReadingMeaning? ReadingMeaning { get; set; }
}


public class Codepoint
{
    [BsonField("type")]
    public string? Type { get; set; }

    [BsonField("value")]
    public string? Value { get; set; }
}

public class Radical
{
    [BsonField("type")]
    public string? Type { get; set; }

    [BsonField("value")]
    public int? Value { get; set; }
}

public class Misc
{
    [BsonField("grade")]
    public int? Grade { get; set; }

    [BsonField("strokeCounts")]
    public List<int>? StrokeCounts { get; set; }

    [BsonField("variants")]
    public List<Variant>? Variants { get; set; }

    [BsonField("frequency")]
    public int? Frequency { get; set; }

    [BsonField("radicalNames")]
    public List<object>? RadicalNames { get; set; }

    [BsonField("jlptLevel")]
    public int? JlptLevel { get; set; }
}

public class DictionaryReference
{
    [BsonField("type")]
    public string? Type { get; set; }

    [BsonField("morohashi")]
    public Morohashi? Morohashi { get; set; }

    [BsonField("value")]
    public string? Value { get; set; }
}

public class QueryCode
{
    [BsonField("type")]
    public string? Type { get; set; }

    [BsonField("SkipMisclassification")]
    public object? SkipMisclassification { get; set; }

    [BsonField("value")]
    public string? Value { get; set; }
}

public class ReadingMeaning
{
    [BsonField("groups")]
    public List<ReadingMeaningGroup>? Groups { get; set; }

    [BsonField("nanori")]
    public List<string>? Nanori { get; set; }
}

public class Variant
{
    [BsonField("type")]
    public string? Type { get; set; }

    [BsonField("value")]
    public string? Value { get; set; }
}

public class Morohashi
{
    [BsonField("volume")]
    public int? Volume { get; set; }

    [BsonField("page")]
    public int? Page { get; set; }
}

public class ReadingMeaningGroup
{
    [BsonField("readings")]
    public List<Reading>? Readings { get; set; }

    [BsonField("meanings")]
    public List<Meaning>? Meanings { get; set; }
}

public class Reading
{
    [BsonField("type")]
    public string? Type { get; set; }

    [BsonField("onType")]
    public object? OnType { get; set; }

    [BsonField("status")]
    public object? Status { get; set; }

    [BsonField("value")]
    public string? Value { get; set; }
}

public class Meaning
{
    [BsonField("lang")]
    public string? Lang { get; set; }

    [BsonField("value")]
    public string? Value { get; set; }
}
