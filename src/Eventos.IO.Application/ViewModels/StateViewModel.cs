namespace Eventos.IO.Application.ViewModels;

public class StateViewModel
{
    public string UF { get; set; }
    public string Name { get; set; }

    public static List<StateViewModel> ShowStates()
    {
        return new List<StateViewModel>()
        {
            new() { UF = "AC", Name = "Acre" },
            new() { UF = "AL", Name = "Alagoas" },
            new() { UF = "AP", Name = "Amapá" },
            new() { UF = "AM", Name = "Amazonas" },
            new() { UF = "BA", Name = "Bahia" },
            new() { UF = "CE", Name = "Ceará" },
            new() { UF = "DF", Name = "Distrito Federal" },
            new() { UF = "ES", Name = "Espírito Santo" },
            new() { UF = "GO", Name = "Goiás" },
            new() { UF = "MA", Name = "Maranhão" },
            new() { UF = "MT", Name = "Mato Grosso" },
            new() { UF = "MS", Name = "Mato Grosso do Sul" },
            new() { UF = "MG", Name = "Minas Gerais" },
            new() { UF = "PA", Name = "Pará" },
            new() { UF = "PB", Name = "Paraíba" },
            new() { UF = "PR", Name = "Paraná" },
            new() { UF = "PE", Name = "Pernambuco" },
            new() { UF = "PI", Name = "Piauí" },
            new() { UF = "RJ", Name = "Rio de Janeiro" },
            new() { UF = "RN", Name = "Rio Grande do Norte" },
            new() { UF = "RS", Name = "Rio Grande do Sul" },
            new() { UF = "RO", Name = "Rondônia" },
            new() { UF = "RR", Name = "Roraima" },
            new() { UF = "SC", Name = "Santa Catarina" },
            new() { UF = "SP", Name = "São Paulo" },
            new() { UF = "SE", Name = "Sergipe" },
            new() { UF = "TO", Name = "Tocantins" }
        };
    }
}
