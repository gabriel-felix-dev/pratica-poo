using System.ComponentModel;
using System.Reflection;

namespace tarefas.Helpers;

public static class EnumHelper
{
    public static string PegaDescricaoEnum(this Enum value) // O this permite pegar o método a partir de alguma propriedade
    {
        FieldInfo informacaoCampo = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] atributos = informacaoCampo.GetCustomAttributes(typeof(DescriptionAttribute), false ) as DescriptionAttribute[]; 
        
        if(atributos != null && atributos.Any())
            return atributos.First().Description;

        return value.ToString();
    }
}
