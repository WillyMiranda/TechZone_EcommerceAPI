using Dapper;
using System.Data;
using System.Text.Json;

namespace TechZone.Ecommerce.Persistence.DapperTypeHandlers
{
    internal sealed class DictionaryStringHandler : SqlMapper.TypeHandler<Dictionary<string, string>>
    {
        public override void SetValue(IDbDataParameter parameter, Dictionary<string, string> value)
        {
            parameter.Value = JsonSerializer.Serialize(value);
            parameter.DbType = DbType.String;
        }

        public override Dictionary<string, string> Parse(object value)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(value.ToString()!)!;
        }
    }
}
