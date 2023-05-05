using System.Buffers;
using System.Text;
using System.Text.Json;

namespace Models;

public class ModelDtoStreamSerializer
{
    private readonly int _writeThreshold;
    private readonly byte[] _nameProperty = Encoding.UTF8.GetBytes(nameof(ModelDto.Name));
    private readonly byte[] _amountProperty = Encoding.UTF8.GetBytes(nameof(ModelDto.Amount));
    private readonly ArrayPool<byte> _pool;

    public ModelDtoStreamSerializer(int writeThreshold)
    {
        _pool = ArrayPool<byte>.Shared;
        _writeThreshold = writeThreshold;
    }
    
    public async ValueTask SerializeAsync(Stream outStream, ModelDto[] data, CancellationToken cancellationToken)
    {
        await using var writer = new Utf8JsonWriter(outStream);
        
        writer.WriteStartArray();

        for (int i = 0; i < data.Length; i+= _writeThreshold)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            var range = new Range(i, i + _writeThreshold);
            WriteSpan(writer, data[range]);
            await writer.FlushAsync(cancellationToken);
        }
        
        writer.WriteEndArray();
    }
    
    private void WriteSpan(Utf8JsonWriter writer, ReadOnlySpan<ModelDto> data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            writer.WriteStartObject();
            writer.WriteString(_nameProperty, data[i].Name.AsSpan());
            writer.WriteNumber(_amountProperty, data[i].Amount);
            writer.WriteEndObject();
        }
    }
}