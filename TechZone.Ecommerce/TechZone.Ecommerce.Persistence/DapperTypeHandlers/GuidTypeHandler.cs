using Dapper;
using System.Data;

namespace TechZone.Ecommerce.Persistence.DapperTypeHandlers
{
    internal sealed class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        // Método para convertir el valor de la base de datos a Guid
        public override Guid Parse(object value)
        {
            // Comprobamos que el valor sea un arreglo de bytes y lo convertimos a Guid.
            if (value is byte[] bytes)
                return new Guid(bytes);
            // Opcionalmente, manejar otros casos (por ejemplo, cuando sea null)
            return Guid.Empty;
        }

        // Método para convertir el Guid a un arreglo de bytes al enviar el parámetro a la base de datos
        public override void SetValue(IDbDataParameter parameter, Guid value)
        {
            parameter.Value = value.ToByteArray();
        }
    }
}
