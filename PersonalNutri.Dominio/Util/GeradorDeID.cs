namespace PersonalNutri.Dominio.Util
{
    //utilizado para facilitar o exemplo, no mundo real, não seria necessário
    public static class GeradorDeId
    {
        private static long _idAtual = 1;
        public  static long ObterIdUnico()
        {
           return _idAtual++;
        }
    }
}
