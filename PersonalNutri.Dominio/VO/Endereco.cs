namespace PersonalNutri.Dominio.VO
{
    public class Endereco
    {
        public long Cep { get; set; }
        public string LinhaDeEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
    }
}
