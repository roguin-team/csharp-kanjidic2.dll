using Kanjidic2.Models;
using LiteDB;

namespace Kanjidic2;

public class Kanjidic2DataAccess : IDisposable
{
    private LiteDatabase _db;
    private ILiteCollection<Kanjidic2Model> _collection;
    private bool disposedValue;

    public Kanjidic2DataAccess()
    {
        if (StaticValue.Kanjidic2Stream is null)
            StaticValue.Kanjidic2Stream = new MemoryStream(MainResource.Kanjidic2);

        _db = new LiteDatabase(StaticValue.Kanjidic2Stream);
        _collection = _db.GetCollection<Kanjidic2Model>("All");
    }

    public IEnumerable<Kanjidic2Model> GetAll() => _collection.FindAll();

    public Kanjidic2Model? Get(string literal) => _collection.FindOne(x => x.Literal == literal);

    public IEnumerable<Kanjidic2Model> GetJLPTKanji(int jlptLevel)
        => _collection.Find(x => x.Misc != null && x.Misc.JlptLevel == jlptLevel);

    public IEnumerable<Kanjidic2Model> GetByKunyomi(string kunReading)
    {
        IEnumerable<BsonValue> bsonValueEnumrable = _db.Execute(
            "SELECT $ FROM All WHERE $.readingMeaning.groups[*].readings[*].type ANY IN 'ja_kun' AND $.readingMeaning.groups[*].readings[*].value ANY IN @0",
            BsonMapper.Global.Serialize(kunReading)).ToEnumerable();

        foreach (BsonValue bsonValue in bsonValueEnumrable)
            yield return BsonMapper.Global.ToObject<Kanjidic2Model>(bsonValue.AsDocument);
    }

    public IEnumerable<Kanjidic2Model> GetByOnyomi(string onReading)
    {
        IEnumerable<BsonValue> bsonValueEnumrable = _db.Execute(
            "SELECT $ FROM All WHERE $.readingMeaning.groups[*].readings[*].type ANY IN 'ja_on' AND $.readingMeaning.groups[*].readings[*].value ANY IN @0",
            BsonMapper.Global.Serialize(onReading)).ToEnumerable();

        foreach (BsonValue bsonValue in bsonValueEnumrable)
            yield return BsonMapper.Global.ToObject<Kanjidic2Model>(bsonValue.AsDocument);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
