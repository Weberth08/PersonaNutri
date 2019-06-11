namespace PersonalNutri.Dominio.VO
{
    public class Nome
    {
        public Nome(string primeiroNome, string sobrenome = null)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public override string ToString() => $"{PrimeiroNome ?? ""} {Sobrenome ?? ""}";
    }
}
